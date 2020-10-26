using Aiesec.Database.Context;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aiesec.Database.Models
{
    public class Team : BaseEntity<int>
    {
        public DateTime EstablishmentDate { get; set; }
        public FunctionalFieldType FunctionalFieldType { get; set; }
        public int FunctionalFieldTypeId { get; set; }
        public LocalCommittee LocalCommittee { get; set; }
        public int LocalCommitteeId { get; set; }
        public int NumberOfMembers { get; set; }
        public List<ProfileTeam> ProfileTeam { get; set; }
        static Team()
        {
            Triggers<Team>.Inserted +=
                entry =>
                {
                    entry.Entity.LocalCommittee = entry.Context.Set<Database.Models.LocalCommittee>().FirstOrDefaultAsync(x => x.Id == entry.Entity.LocalCommitteeId).Result;
                    entry.Entity.LocalCommittee.NumberOfTeams = entry.Context.Set<Team>().Where(x => x.LocalCommitteeId == entry.Entity.LocalCommittee.Id && x.Active == true).Count();
                    entry.Context.Set<LocalCommittee>().Update(entry.Entity.LocalCommittee);
                    entry.Context.SaveChanges();
                };
            Triggers<Team>.Deleted +=
                entry =>
                {
                    entry.Entity.LocalCommittee = entry.Context.Set<Database.Models.LocalCommittee>().FirstOrDefaultAsync(x => x.Id == entry.Entity.LocalCommitteeId).Result;
                    entry.Entity.LocalCommittee.NumberOfTeams = entry.Context.Set<Team>().Where(x => x.LocalCommitteeId == entry.Entity.LocalCommittee.Id && x.Active == true).Count();
                    entry.Context.Set<LocalCommittee>().Update(entry.Entity.LocalCommittee);
                    entry.Context.SaveChanges();
                };
            Triggers<Team>.Updated +=
                entry =>
                {
                    entry.Entity.LocalCommittee = entry.Context.Set<Database.Models.LocalCommittee>().FirstOrDefaultAsync(x => x.Id == entry.Entity.LocalCommitteeId).Result;
                    if (entry.Entity.Active == true)
                    {
                        entry.Entity.LocalCommittee.Active = true;
                        entry.Context.SaveChanges();
                    }
                };
        }
    }
}
