using System;
using Microsoft.AspNetCore.Identity;

namespace Aiesec.Database.Models
{
    public class ApplicationRoleClaim  : IdentityRoleClaim<int>
    {
        
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}