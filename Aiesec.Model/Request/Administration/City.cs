using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aiesec.Model.Request.Administration
{
    public class City
    {
        [Required]
        public string EncryptedId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Postcode { get; set; }
    }
}
