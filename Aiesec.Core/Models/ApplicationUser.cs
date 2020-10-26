using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Aiesec.Database.Models 
{
    public class ApplicationUser : IdentityUser<int> 
    {
        [NotMapped]
        public string EncryptedId { get; set; }
        //[MaxLength(256)]
        // public string UnconfirmedEmail { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
        public bool ChangePassword { get; set; }
    }
}