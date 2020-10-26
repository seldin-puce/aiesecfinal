using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Model.Request.Administration
{
    public class Office
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public int LocalCommitteeId { get; set; }
    }
}
