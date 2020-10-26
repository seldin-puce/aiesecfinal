using Aiesec.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Aiesec.Database.Configurations
{
    public class ProfileTeamConfiguration : IEntityTypeConfiguration<ProfileTeam>
    {
        public void Configure(EntityTypeBuilder<ProfileTeam> builder)
        {
            builder
                .Property(x => x.JoinDate)
                .IsRequired();

            builder
                .Property(x => x.LeaveDate)
                .IsRequired();

            builder
                .HasOne(x => x.Profile)
                .WithMany(x => x.ProfileTeam)
                .HasForeignKey(x => x.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Team)
                .WithMany(x => x.ProfileTeam)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
