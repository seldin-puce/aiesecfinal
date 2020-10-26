using Aiesec.Database.Models;
using EntityFrameworkCore.Triggers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aiesec.Database.Context
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    foreach (var item in builder.Model.GetEntityTypes())
        //    {
        //        if (item.ClrType.GetProperty("CreatedDate") != null && item.ClrType.GetProperty("Active") != null)
        //        {
        //            builder.Entity(item.ClrType).Property("Active").HasDefaultValue(true).ValueGeneratedOnAdd();
        //            builder.Entity(item.ClrType).Property("CreatedDate").HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
        //            builder.Entity(item.ClrType).Property("ModifiedDate").HasDefaultValueSql("getdate()").ValueGeneratedOnUpdate();
        //        }
        //    }
        //    builder.Entity<ApplicationUser>().Property(x => x.ChangePassword).HasDefaultValueSql("1").ValueGeneratedOnAdd();
        //    builder.Entity<ApplicationUser>().Property(x => x.LockoutEnabled).HasDefaultValueSql("1").ValueGeneratedOnAdd();
        //    builder.Entity<ApplicationUser>().Property(x => x.SecurityStamp).HasDefaultValue(Guid.NewGuid().ToString()).ValueGeneratedOnAddOrUpdate();
        //    builder.Entity<ApplicationUserToken>().Property(x => x.TokenType).HasConversion(x => x.ToString(), x => (TokenType)Enum.Parse(typeof(TokenType), x));
        //}

        #region If you're targeting EF Core
        //public override Int32 SaveChanges()
        //{
        //    return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess: true);
        //}
        //public override Int32 SaveChanges(Boolean acceptAllChangesOnSuccess)
        //{
        //    return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess);
        //}
        //public override Task<Int32> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);
        //}
        //public override Task<Int32> SaveChangesAsync(Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess, cancellationToken);
        //}
        #endregion
    }
}