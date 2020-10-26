using Aiesec.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aiesec.Database.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Birthdate)
                .IsRequired();  

            builder
                .Property(x => x.Gender)
                .HasConversion(x => x.ToString(), x => (Gender)Enum.Parse(typeof(Gender), x))
                .IsRequired();

            builder
                .Property(x => x.Biography)
                .HasMaxLength(500)
                .HasDefaultValue("AIESEC-er");

            builder
                .HasOne(x => x.City);
        }
    }
}
