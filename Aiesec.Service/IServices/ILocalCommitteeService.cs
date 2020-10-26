using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Service.IServices
{
    public interface ILocalCommitteeService : 
        ICRUDService<Database.Models.LocalCommittee, Model.Request.Administration.LocalCommittee, Model.Update.Administration.LocalCommittee,
        Model.Response.Administration.LocalCommittee, Model.Search.Administration.LocalCommittee, string, int>
    {
    }
}
