using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Models
{
    public class Position : BaseEntity<int>
    {
        public string Name { get; set; }
        public string  Acronym { get; set; }
    }
}
