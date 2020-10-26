using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Model.Response.Administration
{
    public class LocalCommittee
    {
        public string EncryptedId { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public int NumberOfTeams { get; set; }
        public bool Active { get; set; }
        public int CityId { get; set; }
        public Aiesec.Model.Response.Administration.City City { get; set; }
    }
}
