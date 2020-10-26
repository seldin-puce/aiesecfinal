using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Model.Response.Administration
{
    public class MemberCommittee
    {
        public string EncryptedId { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public int Season { get; set; }
        public int? Active { get; set; }
    }
}
