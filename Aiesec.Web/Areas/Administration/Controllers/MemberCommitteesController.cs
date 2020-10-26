using Aiesec.Service.IServices;
using Aiesec.Web.Controllers;
using Aiesec.Web.Helper;
using Aiesec.Web.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aiesec.Web.Areas.Administration.Controllers
{
    [Authorize]
    [Area(Strings.Area.Administration)]
    public class MemberCommitteesController : BaseDataTableCRUDController<Database.Models.MemberCommittee, Model.Request.Administration.MemberCommittee, Model.Update.Administration.MemberCommittee,
        Model.Response.Administration.MemberCommittee, Model.Search.Administration.MemberCommittee, string, int>
    {
        public MemberCommitteesController(IMemberCommitteeService memberCommitteeService, SharedResource localizer, IMapper mapper) : base(memberCommitteeService, localizer, mapper)
        {
        }
    }
}
