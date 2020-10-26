using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Model.Search.Administration
{
    public  class MemberCommittee
    {
        public string EncryptedId { get; set; }
        public int Season { get; set; }
        public int? Active { get; set; }
    }
}
