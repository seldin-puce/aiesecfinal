using Aiesec.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Configurations
{
    public class FunctionalFieldTypeConfiguration : IEntityTypeConfiguration<FunctionalFieldType>
    {
        public void Configure(EntityTypeBuilder<FunctionalFieldType> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Acronym)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

        }
    }
}