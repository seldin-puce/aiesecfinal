using Aiesec.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Configurations
{
    class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .Property(x => x.EstablishmentDate)
                .IsRequired();

            builder
                .HasOne(x => x.FunctionalFieldType);

            builder
                .HasOne(x => x.LocalCommittee);
        }
    }
}