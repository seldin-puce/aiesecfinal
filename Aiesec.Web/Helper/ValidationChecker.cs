using Aiesec.Database.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aiesec.Web.Helper
{
    public class ValidationChecker
    {
        private readonly AuthContext _authContext;

        public ValidationChecker(AuthContext authContext)
        {
            _authContext = authContext;
        }
    }
}
