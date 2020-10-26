using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Aiesec.Database.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}