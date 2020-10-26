using Aiesec.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiesec.Database.Configurations
{
    public class MemberCommitteeConfiguration : IEntityTypeConfiguration<MemberCommittee>
    {
        public void Configure(EntityTypeBuilder<MemberCommittee> builder)
        {
            builder
                .Property(x => x.Season)
                .HasMaxLength(9)
                .IsRequired();

            builder
                .Property(x => x.EstablishmentDate)
                .IsRequired();
        }
    }
}
