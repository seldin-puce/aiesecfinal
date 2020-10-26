using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aiesec.Model.Update.Administration
{
    public class Team
    {
        [Required]
        public DateTime EstablishmentDate { get; set; }
        [Required]
        public int FunctionalFieldTypeId { get; set; }
        [Required]
        public int LocalCommitteeId { get; set; }
    }
}
