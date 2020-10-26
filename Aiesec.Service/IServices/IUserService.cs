using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aiesec.Service.IServices
{
    public interface IUserService : IAuthService<IdentityUser, IdentityUser,
        IdentityUser, IdentityUser, IdentityUser, string, int>
    {
        //Task<Model.Response.Administration.User> ChangeActiveStatusAsync(string encryptedId);
        //Task<Tuple<List<Model.Response.Administration.User>, List<int>>> TakeRecordsAndIdsByNumberAsync(int take = 10);
        //Task<Tuple<List<Model.Response.Administration.User>, List<int>>> GetByParametersAndIdsAsync(Model.Search.Administration.User search, List<int> profileIds, string order, string nameOfColumn, int start, int length);
    }
}