using Aiesec.Database.Context;
using Aiesec.Service.Extensions;
using Aiesec.Service.IServices;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiesec.Service.Services
{
    public class OfficeService : CRUDService<Database.Models.Office, Model.Request.Administration.Office, Model.Update.Administration.Office, Model.Response.Administration.Office,
        Model.Search.Administration.Office, string, int>, IOfficeService
    {
        private readonly DBContext _dbContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public OfficeService(DBContext dbContext, ILogger<OfficeService> logger, IMapper mapper, IDataProtectionProvider protectionProvider) : base(dbContext, logger, mapper, protectionProvider)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<List<Model.Response.Administration.Office>> TakeRecordsByNumberAsync(int take = 10)
        {
            List<Database.Models.Office> result = await _dbContext.Set<Database.Models.Office>().Include(x => x.LocalCommittee).Include(x => x.LocalCommittee.City).Take(take).ToListAsync().ConfigureAwait(false);
            EncryptList(result);
            return _mapper.Map<List<Model.Response.Administration.Office>>(result);
        }

        public override async Task<Tuple<List<Model.Response.Administration.Office>, int>> GetByParametersAsync(Model.Search.Administration.Office search, string order, string orderColumn, int start, int length)
        {
            IQueryable<Database.Models.Office> query = _dbContext.Set<Database.Models.Office>().Include(x => x.LocalCommittee)
               .Include(x => x.LocalCommittee.City).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.LocalCommittee))
                query = query.Where(x => x.LocalCommittee.City.Name == search.LocalCommittee);

            if (search.EstablishmentDate.HasValue)
                query = query.Where(x => x.EstablishmentDate == search.EstablishmentDate);

            switch (orderColumn)
            {
                case nameof(Aiesec.Model.Response.Administration.Team.EstablishmentDate):
                    query = query.OrderByAscDesc(x => x.EstablishmentDate, order);
                    break;

                case nameof(Aiesec.Model.Response.Administration.Team.Active):
                    query = query.OrderByAscDesc(x => x.Active, order);
                    break;
            };

            List<Database.Models.Office> result = await query.Skip(start).Take(length).ToListAsync().ConfigureAwait(false);
            EncryptList(result);

            return new Tuple<List<Model.Response.Administration.Office>, int>(_mapper.Map<List<Model.Response.Administration.Office>>(result), result.Count);
        }
    }
}
