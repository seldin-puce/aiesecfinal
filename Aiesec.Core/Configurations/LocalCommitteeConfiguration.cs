using Aiesec.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Configurations
{
    class LocalCommitteeConfiguration : IEntityTypeConfiguration<LocalCommittee>
    {
        public void Configure(EntityTypeBuilder<LocalCommittee> builder)
        {
            builder
                .Property(x => x.EstablishmentDate)
                .IsRequired();

            builder
                .HasOne(x => x.City);
        }
    }
}

