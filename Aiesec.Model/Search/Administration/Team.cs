using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Model.Search.Administration
{
    public class Team
    {
        public int NumberOfMembers { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public string FunctionalFieldType { get; set; }
        public string LocalCommittee { get; set; }
        public int? Active { get; set; }

    }
}
