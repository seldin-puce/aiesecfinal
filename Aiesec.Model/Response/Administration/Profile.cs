using Aiesec.Database.Models;
using System;
using Aiesec.Model.Response.Administration;

namespace Aiesec.Model.Response.Administration
{
    public class Profile
    {
        public string EncryptedId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public int CityId { get; set; }
        public Response.Administration.City City { get; set; }
        public string Address { get; set; }
    }
}
