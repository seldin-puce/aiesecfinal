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
using System.Text;
using System.Threading.Tasks;

namespace Aiesec.Service.Services
{
    public class TeamService : CRUDService<Database.Models.Team, Model.Request.Administration.Team, Model.Update.Administration.Team, Model.Response.Administration.Team,
        Model.Search.Administration.Team, string, int>, ITeamService
    {
        private readonly DBContext _dbContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public TeamService(DBContext dbContext, ILogger<TeamService> logger, IMapper mapper, IDataProtectionProvider protectionProvider) : base(dbContext, logger, mapper, protectionProvider)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<List<Model.Response.Administration.Team>> TakeRecordsByNumberAsync(int take = 10)
        {
            List<Database.Models.Team> result = await _dbContext.Set<Database.Models.Team>().Include(x => x.FunctionalFieldType)
                .Include(x => x.LocalCommittee).Include(x => x.LocalCommittee.City).Take(take).ToListAsync().ConfigureAwait(false);
            EncryptList(result);
            return _mapper.Map<List<Model.Response.Administration.Team>>(result);
        }

        public override async Task<Model.Response.Administration.Team> GetByIdAsync(string encryptedId)
        {
            Database.Models.Team result = await _dbContext.Set<Database.Models.Team>().Include(x => x.FunctionalFieldType).Include(x => x.LocalCommittee)
                .Include(x => x.LocalCommittee.City).FirstOrDefaultAsync(x => x.Id == DecryptId(encryptedId)).ConfigureAwait(false);
            EncryptId(result);
            return _mapper.Map<Model.Response.Administration.Team>(result);
        }

        public override async Task<Tuple<List<Model.Response.Administration.Team>, int>> GetByParametersAsync(Model.Search.Administration.Team search, string order, string orderColumn, int start, int length)
        {
            IQueryable<Database.Models.Team> query = _dbContext.Set<Database.Models.Team>().Include(x => x.LocalCommittee)
                .Include(x => x.FunctionalFieldType).Include(x => x.LocalCommittee.City).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.LocalCommittee))
                query = query.Where(x => x.LocalCommittee.City.Name == search.LocalCommittee);

            if (search.EstablishmentDate.HasValue)
                query = query.Where(x => x.EstablishmentDate == search.EstablishmentDate);

            if (!string.IsNullOrWhiteSpace(search.FunctionalFieldType)) 
                query = query.Where(x => x.FunctionalFieldType.Acronym == search.FunctionalFieldType);

            if (search.Active.HasValue)
                query = query.Where(x => x.Active == Convert.ToBoolean(search.Active));

            switch (orderColumn)
            {
                case nameof(Aiesec.Model.Response.Administration.Team.LocalCommittee.City.Name):
                    query = query.OrderByAscDesc(x => x.LocalCommittee.City.Name, order);
                    break;

                case nameof(Aiesec.Model.Response.Administration.Team.FunctionalFieldType.Acronym):
                    query = query.OrderByAscDesc(x => x.FunctionalFieldType.Acronym, order);
                    break;

                case nameof(Aiesec.Model.Response.Administration.Team.EstablishmentDate):
                    query = query.OrderByAscDesc(x => x.EstablishmentDate, order);
                    break;

                case nameof(Aiesec.Model.Response.Administration.Team.NumberOfMembers):
                    query = query.OrderByAscDesc(x => x.NumberOfMembers, order);
                    break;
                case nameof(Aiesec.Model.Response.Administration.Team.Active):
                    query = query.OrderByAscDesc(x => x.Active, order);
                    break;
            };

            List<Database.Models.Team> result = await query.Skip(start).Take(length).ToListAsync().ConfigureAwait(false);
            EncryptList(result);

            return new Tuple<List<Model.Response.Administration.Team>, int>(_mapper.Map<List<Model.Response.Administration.Team>>(result), result.Count);
        }

        public override async Task<Model.Response.Administration.Team> ChangeActiveStatusAsync(string encryptedId)
        {
            Database.Models.Team model = await _dbContext.Set<Database.Models.Team>().Include(x => x.LocalCommittee).Include(x => x.LocalCommittee.City).Include(x => x.FunctionalFieldType)
                .FirstOrDefaultAsync(x => x.Id == DecryptId(encryptedId)).ConfigureAwait(false);
            model.Active = !model.Active;
            try
            {
                _dbContext.Set<Database.Models.Team>().Update(model);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                // TODO: Dodati log operaciju
            }
            catch
            {
                //TODO: Dodati log operaciju
                throw;
            }
            EncryptId(model);
            return _mapper.Map<Model.Response.Administration.Team>(model);
        }
    }
}
