using Aiesec.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aiesec.Model.Request.Administration
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
