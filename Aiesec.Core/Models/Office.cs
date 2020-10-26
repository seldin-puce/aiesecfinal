using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Models
{
    public class Office : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public LocalCommittee LocalCommittee { get; set; }
        public int LocalCommitteeId { get; set; }
    }
}
