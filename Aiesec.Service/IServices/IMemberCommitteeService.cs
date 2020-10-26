using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Service.IServices
{
    public interface IMemberCommitteeService : ICRUDService<Database.Models.MemberCommittee, Model.Request.Administration.MemberCommittee, Model.Update.Administration.MemberCommittee,
        Model.Response.Administration.MemberCommittee, Model.Search.Administration.MemberCommittee, string, int>
    {
    }
}
