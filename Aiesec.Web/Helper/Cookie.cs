using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aiesec.Web.Helper
{
    public static class Cookie
    {
        public static void SetCultureInfoCookie(this IResponseCookies cookies, RequestCulture culture)
        {
            cookies.Delete(Localization.CurrentCultureCookieName);
            cookies.Append(Localization.CurrentCultureCookieName, CookieRequestCultureProvider.MakeCookieValue(culture));
        }
    }
}
