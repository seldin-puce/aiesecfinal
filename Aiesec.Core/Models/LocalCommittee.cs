using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aiesec.Database.Models
{
    public class LocalCommittee : BaseEntity<int>
    {
        public DateTime EstablishmentDate { get; set; }
        public int CityId { get; set; }
        public Aiesec.Database.Models.City City { get; set; }
        public int NumberOfTeams { get; set; }
        public Office Office { get; set; }
        static LocalCommittee()
        {
            Triggers<LocalCommittee>.Updated +=
                 entry =>
                {
                    if (entry.Entity.Active == false)
                    {
                        IQueryable<Team> data = entry.Context.Set<Team>().Where(x => x.LocalCommitteeId == entry.Entity.Id);
                        data.ForEachAsync(x => x.Active = false);
                        entry.Context.SaveChanges();
                    }
                    else
                    {
                        IQueryable<Team> data = entry.Context.Set<Team>().Where(x => x.LocalCommitteeId == entry.Entity.Id);
                        data.ForEachAsync(x => x.Active = true);
                        entry.Context.SaveChanges();
                    }
                };
        }
    }
}