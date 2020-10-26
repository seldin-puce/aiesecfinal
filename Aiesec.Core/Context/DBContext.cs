using System.Linq;
using Aiesec.Database.Models;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;


namespace Aiesec.Database.Context
{
    public class DBContext : DbContextWithTriggers
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ProfilePhoto> ProfilePhotos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);

            var cascadefks = builder.Model.GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys())
                .Where(x => x.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var item in cascadefks)
                item.DeleteBehavior = DeleteBehavior.Restrict;
            foreach (var entityType in builder.Model.GetEntityTypes()
                .Where(e => typeof(BaseEntity<int>).IsAssignableFrom(e.ClrType)))
            {
                builder
                    .Entity(entityType.ClrType)
                    .Property("CreatedDate")
                    .HasDefaultValueSql("getdate()")
                    .ValueGeneratedOnAdd();
                builder
                    .Entity(entityType.ClrType)
                    .Property("Active")
                    .HasDefaultValueSql("1")
                    .ValueGeneratedOnAdd();
                builder
                    .Entity(entityType.ClrType)
                    .Property("ModifiedDate")
                    .HasDefaultValueSql("getdate()")
                    .ValueGeneratedOnUpdate();
            }
        }
    }
}