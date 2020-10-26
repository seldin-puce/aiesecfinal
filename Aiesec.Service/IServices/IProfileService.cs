using Aiesec.Model.Update.Administration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aiesec.Service.IServices
{
    public interface IProfileService : ICRUDService<Database.Models.Profile, Model.Request.Administration.Profile,
        Model.Update.Administration.Profile, Model.Response.Administration.Profile, Model.Search.Administration.Profile, string, int>
    {
        Task<List<Model.Response.Administration.Profile>> TakeRecordsByNumberAndIdsAsync(List<int> userIds, int take = 10);
        Task<Tuple<List<Model.Response.Administration.Profile>, List<int>>> GetByParametersAndIdsAsync(Model.Search.Administration.Profile search, List<int> userIds, string order, string orderColumn, int start, int length);
    }
}
