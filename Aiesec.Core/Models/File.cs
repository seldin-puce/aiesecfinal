using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Models
{
    public class File : BaseEntity<int>
    {
        public string Path { get; set; }
        public string FileSystemPath { get; set; }
        public string Name { get; set; }
        public int SizeInBytes { get; set; }
        public string Extension { get; set; }
    }
}
