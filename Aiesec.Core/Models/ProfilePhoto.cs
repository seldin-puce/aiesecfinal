using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Models
{
    public class ProfilePhoto : File
    {
        public float Height { get; set; }
        public float Width { get; set; }
        public float XResolution { get; set; }
        public float YResolution { get; set; }
        public string ResolutionUnit { get; set; }
        public int ProfileId { get; set; }
    }
}
