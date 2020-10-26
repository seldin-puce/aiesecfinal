using Aiesec.Web.Helper;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Primitives;

namespace Aiesec.Web.Language
{
    public class LanguageController : Controller
    {
        public IActionResult Change(string culture)
        {
            if (!string.IsNullOrWhiteSpace(culture) && Localization.SupportedCultures.Any(x => x.Name == culture))
            {
                CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                Response.Cookies.SetCultureInfoCookie(new RequestCulture(culture));
            }

            if (Request.Headers["Referer"] != StringValues.Empty)
                return Redirect(Request.Headers["Referer"]);
            return LocalRedirect("~/");
        }
    }
}