using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aiesec.Service.IServices;
using Aiesec.Service.Services;
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
    public class LocalCommitteesController :
        BaseDataTableCRUDController<Database.Models.LocalCommittee, Model.Request.Administration.LocalCommittee,
            Model.Update.Administration.LocalCommittee, Model.Response.Administration.LocalCommittee,
            Model.Search.Administration.LocalCommittee, string, int>
    {
        public LocalCommitteesController(ILocalCommitteeService localCommitteeService, SharedResource sharedResource,
            IMapper mapper) : base(localCommitteeService, sharedResource, mapper)
        {
        }
    }
}
