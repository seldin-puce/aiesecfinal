using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aiesec.Database.Context;
using Aiesec.Service.Extensions;
using Aiesec.Service.IServices;
using Aiesec.Service.Settings;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aiesec.Service.Services
{
    public class UserService :
        AuthService<IdentityUser, IdentityUser, IdentityUser,
           IdentityUser, IdentityUser, string, int>, IUserService
    {
        private readonly AuthContext _authContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public UserService(AuthContext authContext, ILogger<UserService> logger, IMapper mapper, IDataProtectionProvider protectionProvider) : base(
            authContext, logger, mapper, protectionProvider)
        {
            _authContext = authContext;
            _logger = logger;
            _mapper = mapper;
        }

        //public async Task<Model.Response.Administration.User> ChangeActiveStatusAsync(string encryptedId)
        //{
        //    int decryptedId = DecryptId(encryptedId);
        //    Database.Models.ApplicationUser model = await _authContext.Set<Database.Models.ApplicationUser>().FindAsync(decryptedId).ConfigureAwait(false);
        //    model.Active = !model.Active;
        //    try
        //    {
        //        _authContext.Users.Update(model);
        //        await _authContext.SaveChangesAsync().ConfigureAwait(false);
        //        EncryptId(model);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _mapper.Map<Model.Response.Administration.User>(model);
        //}

        //public async Task<Tuple<List<Model.Response.Administration.User>, List<int>>> TakeRecordsAndIdsByNumberAsync(int take = 10)
        //{
        //    List<int> userIds = new List<int>();
        //    List<Database.Models.ApplicationUser> result = await _authContext.Set<Database.Models.ApplicationUser>().Take(take).OrderByAscDesc(x => x.Id, "asc").ToListAsync().ConfigureAwait(false);
        //    foreach (Database.Models.ApplicationUser item in result)
        //    {
        //        EncryptId(item);
        //        userIds.Add(item.Id);
        //    }
        //    return new Tuple<List<Model.Response.Administration.User>, List<int>>(_mapper.Map<List<Model.Response.Administration.User>>(result), userIds);
        //}

        public async Task<Tuple<List<Model.Response.Administration.User>, List<int>>> GetByParametersAndIdsAsync(Model.Search.Administration.User search, List<int> profileIds,
                string order, string orderColumn, int start, int length)
        {
            IQueryable<Database.Models.ApplicationUser> query = _authContext.Set<Database.Models.ApplicationUser>().AsQueryable();
            List<int> filteredIds = new List<int>();

            if (profileIds is object)
                query = query.Where(x => profileIds.Contains(x.Id));

            if (!string.IsNullOrWhiteSpace(search.UserName))
                query = query.Where(x => x.UserName.Contains(search.UserName));

            if (!string.IsNullOrWhiteSpace(search.Email))
                query = query.Where(x => x.Email.Contains(search.Email));

            if (!string.IsNullOrEmpty(search.PhoneNumber))
                query = query.Where(x => x.PhoneNumber.Contains(search.PhoneNumber));

            if (search.DateFrom.HasValue)
                query = query.Where(x => x.CreatedDate >= search.DateFrom);

            if (search.DateTo.HasValue)
                query = query.Where(x => x.CreatedDate <= search.DateTo);

            if (search.Active.HasValue)
                query = query.Where(x => x.Active == Convert.ToBoolean(search.Active));

            switch (orderColumn)
            {
                case nameof(Model.Response.Administration.User.UserName):
                    query = query.OrderByAscDesc(x => x.UserName, order);
                    break;

                case nameof(Model.Response.Administration.User.Email):
                    query = query.OrderByAscDesc(x => x.Email, order);
                    break;

                case nameof(Model.Response.Administration.User.CreatedDate):
                    query = query.OrderByAscDesc(x => x.CreatedDate, order);
                    break;

                case nameof(Model.Response.Administration.User.Active):
                    query = query.OrderByAscDesc(x => x.Active, order);
                    break;
                default:
                    if (profileIds is object)
                        query = query.OrderBy(x => profileIds.IndexOf(x.Id));
                    break;
            };

            var result = await query.Skip(start).Take(length).ToListAsync().ConfigureAwait(false);
            EncryptList(result);

            return new Tuple<List<Model.Response.Administration.User>, List<int>>(_mapper.Map<List<Model.Response.Administration.User>>(result), filteredIds);
        }
    }
}