using Aiesec.Database.Context;
using Aiesec.Model.Response.Administration;
using Aiesec.Service.Extensions;
using Aiesec.Service.IServices;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aiesec.Service.Services
{
    public class LocalCommitteeService :
        CRUDService<Database.Models.LocalCommittee, Model.Request.Administration.LocalCommittee, Model.Update.Administration.LocalCommittee,
            Model.Response.Administration.LocalCommittee, Model.Search.Administration.LocalCommittee, string, int>, ILocalCommitteeService
    {
        private readonly DBContext _dbContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public LocalCommitteeService(DBContext dbContext, ILogger<LocalCommitteeService> logger, IMapper mapper, IDataProtectionProvider protectionProvider)
            : base(dbContext, logger, mapper, protectionProvider)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<List<Model.Response.Administration.LocalCommittee>> TakeRecordsByNumberAsync(int take = 10)
        {
            List<Database.Models.LocalCommittee> result = await _dbContext.Set<Database.Models.LocalCommittee>().Include(x => x.City).Take(take).ToListAsync().ConfigureAwait(false);
            EncryptList(result);
            return _mapper.Map<List<Model.Response.Administration.LocalCommittee>>(result);
        }

        public override async Task<Model.Response.Administration.LocalCommittee> GetByIdAsync(string id)
        {
            try
            {
                var result = await _dbContext.Set<Database.Models.LocalCommittee>().Include(x => x.City).FirstOrDefaultAsync(x => x.Id == DecryptId(id)).ConfigureAwait(false);
                EncryptId(result);
                return _mapper.Map<Model.Response.Administration.LocalCommittee>(result);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<Tuple<List<Model.Response.Administration.LocalCommittee>, int>> GetByParametersAsync(Model.Search.Administration.LocalCommittee search, string order, string orderColumn, int start, int length)
        {
            IQueryable<Database.Models.LocalCommittee> query = _dbContext.Set<Database.Models.LocalCommittee>().Include(x => x.City).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.City))
                query = query.Where(x => x.City.Name == search.City);

            if (search.EstablishmentDate.HasValue)
                query = query.Where(x => x.EstablishmentDate == search.EstablishmentDate);

            if (search.Active.HasValue)
                query = query.Where(x => x.Active == Convert.ToBoolean(search.Active));

            switch (orderColumn)
            {
                case nameof(Model.Response.Administration.LocalCommittee.City.Name):
                    query = query.OrderByAscDesc(x => x.City.Name, order);
                    break;

                case nameof(Model.Response.Administration.LocalCommittee.EstablishmentDate):
                    query = query.OrderByAscDesc(x => x.EstablishmentDate, order);
                    break;

                case nameof(Model.Response.Administration.LocalCommittee.Active):
                    query = query.OrderByAscDesc(x => x.Active, order);
                    break;

                case nameof(Model.Response.Administration.LocalCommittee.NumberOfTeams):
                    query = query.OrderByAscDesc(x => x.NumberOfTeams, order);
                    break;
            };

            List<Database.Models.LocalCommittee> result = await query.Skip(start).Take(length).ToListAsync().ConfigureAwait(false);
            EncryptList(result);

            return new Tuple<List<Model.Response.Administration.LocalCommittee>, int>(_mapper.Map<List<Model.Response.Administration.LocalCommittee>>(result), result.Count);
        }

        public override async Task<Model.Response.Administration.LocalCommittee> ChangeActiveStatusAsync(string encryptedId)
        {
            Database.Models.LocalCommittee model = await _dbContext.Set<Database.Models.LocalCommittee>().Include(x => x.City).FirstOrDefaultAsync(x => x.Id == DecryptId(encryptedId));
            model.Active = !model.Active;
            try
            {
                _dbContext.Set<Database.Models.LocalCommittee>().Update(model);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                // TODO: Dodati log operaciju
            }
            catch
            {
                //TODO: Dodati log operaciju
                throw;
            }
            EncryptId(model);
            return _mapper.Map<Model.Response.Administration.LocalCommittee>(model);
        }
    }
}
