using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Aiesec.Web
{
    public class Constants
    {
        private readonly IStringLocalizer _localizer;

        public Constants(IStringLocalizerFactory localizerFactory)
        {
            _localizer = localizerFactory.Create(nameof(Constants), new AssemblyName(typeof(Constants).Assembly.FullName).Name);
        }

        public IEnumerable<string> Genders
        {
            get
            {
                IEnumerable<string> data = _localizer[nameof(Genders)].ToString().Split(";");
                return data;
            }
        }

        public IEnumerable<string> Roles
        {
            get
            {
                IEnumerable<string> data = _localizer[nameof(Roles)].ToString().Split(";");
                return data;
            }
        }
    }
}
