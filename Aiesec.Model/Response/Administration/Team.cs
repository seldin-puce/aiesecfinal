using System;

namespace Aiesec.Model.Response.Administration
{
    public class Team
    {
        public string EncryptedId { get; set; }
        public bool Active { get; set; }
        public int NumberOfMembers { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public FunctionalFieldType FunctionalFieldType { get; set; }
        public int FunctionalFieldTypeId { get; set; }
        public LocalCommittee LocalCommittee { get; set; }
        public int LocalCommitteeId { get; set; }
    }
}
