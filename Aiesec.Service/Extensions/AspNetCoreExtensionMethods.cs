using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Aiesec.Service.Extensions
{
    public static class AspNetCoreExtensionMethods
    {
        public static ModelStateDictionary AddModelErrors(this ModelStateDictionary dictionary, IEnumerable<IdentityError> identityErrors)
        {
            if (identityErrors == null)
                throw new ArgumentNullException(nameof(identityErrors));
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            foreach (IEnumerable<IdentityError> error in identityErrors)
            {
                dictionary.AddModelError(error.Code, error.Description);
            }
            return dictionary;
        }
    }
}
