using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Model.Response.Administration
{
    public class Office
    {
        public string EncryptedId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public int? Active { get; set; }
        public int LocalCommitteeId { get; set; }
        public Model.Response.Administration.LocalCommittee LocalCommittee { get; set; }
    }
}
