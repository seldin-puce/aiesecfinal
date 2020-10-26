using Aiesec.Database.Context;
using Aiesec.Model.Request.Administration;
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
    public class ProfileService : CRUDService<Database.Models.Profile, Model.Request.Administration.Profile,
        Model.Update.Administration.Profile, Model.Response.Administration.Profile, Model.Search.Administration.Profile, string, int>, IProfileService
    {
        private readonly DBContext _dbContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ProfileService(DBContext dbContext, ILogger<ProfileService> logger, IMapper mapper, IDataProtectionProvider protectionProvider)
            : base(dbContext, logger, mapper, protectionProvider)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public virtual async Task<List<Model.Response.Administration.Profile>> TakeRecordsByNumberAndIdsAsync(List<int> userIds, int take = 10)
        {
            IQueryable<Database.Models.Profile> query = _dbContext.Profiles.AsQueryable();

            if (userIds is object)
                query = query.Where(x => userIds.Contains(x.Id));

            List<Database.Models.Profile> result = await query.Take(take).ToListAsync().ConfigureAwait(false);
            foreach (Database.Models.Profile item in result)
            {
                EncryptId(item);
            }
            return _mapper.Map<List<Model.Response.Administration.Profile>>(result.OrderBy(x => userIds.IndexOf(x.Id)));
        }

        public async Task<Tuple<List<Model.Response.Administration.Profile>, List<int>>> GetByParametersAndIdsAsync(Model.Search.Administration.Profile search, List<int> userIds, string order, string orderColumn, int start, int length)
        {
            IQueryable<Database.Models.Profile> query = _dbContext.Profiles.AsQueryable();

            List<int> filteredIds = new List<int>();

            if (userIds is object)
                query = query.Where(x => userIds.Contains(x.Id));

            IEnumerable<Database.Models.Profile> result = await  query.ToListAsync().ConfigureAwait(false);

            switch (orderColumn)
            {
                default:
                    result = result.OrderBy(x => userIds.IndexOf(x.Id));
                    break;
            }

            foreach (Database.Models.Profile item in result)
            {
                filteredIds.Add(item.Id);
            }

            return new Tuple<List<Model.Response.Administration.Profile>, List<int>>(_mapper.Map<List<Model.Response.Administration.Profile>>(result), filteredIds);
        }

        public async override Task<Model.Response.Administration.Profile> GetByIdAsync(string id)
        {
            try
            {
                Model.Response.Administration.Profile model = _mapper.Map<Model.Response.Administration.Profile>(
                    await _dbContext.Profiles.Include(x => x.City).SingleOrDefaultAsync(x => x.Id == DecryptId(id)).ConfigureAwait(false));
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
