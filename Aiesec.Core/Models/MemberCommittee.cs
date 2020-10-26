using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Models
{
    public class MemberCommittee : BaseEntity<int>
    {
        public DateTime EstablishmentDate { get; set; }
        public int Season { get; set; }
    }
}
