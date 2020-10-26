using System.Threading.Tasks;
using Aiesec.Web.Helper;
using Aiesec.Web.Resources;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aiesec.Web.Areas.Administration.Controllers
{
    [Area(Strings.Area.TeamMember)]
    public class ProfilesController : Controller
    {
        private readonly SharedResource _sharedResource;

        public ProfilesController(SharedResource sharedResource)
        {
            _sharedResource = sharedResource;
        }

        public IActionResult ChangeProfilePhoto([FromRoute] string encryptedId)
        {
            ViewBag.ProfileId = encryptedId;
            return View();
        }
    }
}
