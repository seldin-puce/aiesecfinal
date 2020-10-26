using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Models
{
    public class FunctionalFieldType : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Acronym { get; set; }
        public string Description { get; set; }

    }
}
