using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aiesec.Model.Update.Administration
{
    public class LocalCommittee
    {
        [Required]
        public DateTime EstablishmentDate { get; set; }
        [Required]
        public int CityId { get; set; }
    }
}
