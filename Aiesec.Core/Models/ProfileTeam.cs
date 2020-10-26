using Aiesec.Database.Configurations;
using EntityFrameworkCore.Triggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Models
{
    public class ProfileTeam : BaseEntity<int>
    {
        public DateTime JoinDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }

        static ProfileTeam()
        {
            Triggers<ProfileTeam>.Inserting +=
                entry => entry.Entity.Team.NumberOfMembers += 1;
            Triggers<ProfileTeam>.Deleting +=
                entry => entry.Entity.Team.NumberOfMembers -= 1;
        }
    }
}
