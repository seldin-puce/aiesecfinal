using Aiesec.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Configurations
{
    public class OfficeConfiguration : BaseEntity<int>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Address)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Capacity)
                .IsRequired();

            builder
                .HasOne<LocalCommittee>()
                .WithOne(x => x.Office)
                .HasForeignKey<Office>(x => x.LocalCommitteeId);
        }
    }
}
