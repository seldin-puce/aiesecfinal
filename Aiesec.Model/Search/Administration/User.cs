using System;

namespace Aiesec.Model.Search.Administration
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? Active { get; set; }
    }
}