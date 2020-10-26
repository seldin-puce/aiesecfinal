using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Model.Search.Administration
{
    public class LocalCommittee
    {
        public string City { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public int? Active { get; set; }
        public int? NumberOfTeams { get; set; }
    }
}
