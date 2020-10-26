using System;

namespace Aiesec.Model.Response.Administration
{
    public class User
    {
        public string EncryptedId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool ChangePassword { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}