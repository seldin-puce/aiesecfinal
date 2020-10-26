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
    public class TeamsController : BaseDataTableCRUDController<Database.Models.Team, Model.Request.Administration.Team, Model.Update.Administration.Team, Model.Response.Administration.Team,
        Model.Search.Administration.Team, string, int>
    {
        public TeamsController(ITeamService teamService, SharedResource sharedResource,
            IMapper mapper) :
            base(teamService, sharedResource, mapper)
        {
        }
    }
}
