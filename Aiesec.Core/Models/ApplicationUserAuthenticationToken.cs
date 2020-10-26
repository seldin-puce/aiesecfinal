using System;
using Microsoft.AspNetCore.Identity;

namespace Aiesec.Database.Models
{
    public class ApplicationUserAuthenticationToken : IdentityUserToken<int>
    {
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}