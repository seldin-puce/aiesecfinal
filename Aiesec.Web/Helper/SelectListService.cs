using Aiesec.Database.Context;
using Aiesec.Web.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aiesec.Web.Helper
{
    public class SelectListService : ISelectListService
    {
        private readonly AuthContext _authContext;
        private readonly DBContext _dbContext;
        private readonly SharedResource _sharedResource;
        private readonly IMapper _mapper;
        private readonly Constants _constants;


        public SelectListService(AuthContext authContext, DBContext dBContext, SharedResource sharedResource, IMapper mapper, Constants constants)
        {
            _authContext = authContext;
            _dbContext = dBContext;
            _sharedResource = sharedResource;
            _mapper = mapper;
            _constants = constants;
        }

        public IEnumerable<SelectListItem> BaseSelectListItem(bool includeChooseText, string chooseText, IEnumerable<SelectListItem> selectListItems)
        {
            var items = new List<SelectListItem>();
            if (includeChooseText)
                items.Add(new SelectListItem { Text = chooseText, Value = string.Empty });
            if (selectListItems != null)
                items.AddRange(selectListItems);
            return items;
        }

        public async ValueTask<IEnumerable<SelectListItem>> Cities(bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, _sharedResource.ChooseCity, _mapper.Map<List<SelectListItem>>(await _dbContext.Set<Database.Models.City>().Where(x => x.Active).ToListAsync()));
        }

        public async ValueTask<IEnumerable<SelectListItem>> Roles(bool includeChooseText = true)
        {
            return await Task.FromResult(BaseSelectListItem(includeChooseText, _sharedResource.ChooseRole, _constants.Roles.Zip(
                Enum.GetNames(typeof(Database.Models.Enum.Roles)), (s, s1) => new SelectListItem(s, s1))));
        }

        public async ValueTask<IEnumerable<SelectListItem>> Genders(bool includeChooseText = true)
        {
            return await Task.FromResult(BaseSelectListItem(includeChooseText, _sharedResource.ChooseGender, _constants.Genders.Zip(
                Enum.GetNames(typeof(Database.Models.Gender)),
                (s, s1) => new SelectListItem(s, s1))));
        }

        public async ValueTask<IEnumerable<SelectListItem>> FunctionalFields(bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, _sharedResource.ChooseCity, _mapper.Map<List<SelectListItem>>(await _dbContext.Set<Database.Models.FunctionalFieldType>().Where(x => x.Active).ToListAsync()));
        }

        public async ValueTask<IEnumerable<SelectListItem>> LocalCommittees(bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, _sharedResource.ChooseLocalCommittee, _mapper.Map<List<SelectListItem>>(
                await _dbContext.Set<Database.Models.LocalCommittee>().Include(x => x.City).Where(x => x.Active).ToListAsync()));
        }
    }
}
