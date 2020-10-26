using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Models
{
    public class Composition : BaseEntity<int>
    {
        MemberCommittee MemberCommittee { get; set; }
        public int MemberCommitteeId { get; set; }
        public FunctionalFieldType FunctionalFieldType { get; set; }
        public int FunctionalFieldTypeId { get; set; }
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
    }
}
