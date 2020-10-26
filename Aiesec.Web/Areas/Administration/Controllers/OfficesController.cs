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
    public class OfficesController : BaseDataTableCRUDController<Database.Models.Office, Model.Request.Administration.Office, Model.Update.Administration.Office, Model.Response.Administration.Office,
        Model.Search.Administration.Office, string, int>
    {
        public OfficesController(IOfficeService officeService, SharedResource localizer, IMapper mapper) : base(officeService, localizer, mapper)
        {
        }
    }
}
