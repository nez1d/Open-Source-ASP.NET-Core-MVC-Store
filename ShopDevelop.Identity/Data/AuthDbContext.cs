using Microsoft.EntityFrameworkCore;
using ShopDevelop.Identity.Data.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ShopDevelop.Identity.Models.User;

namespace ShopDevelop.Identity.Data
{
    public class AuthDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>(entity =>
                entity.ToTable(name: "Users"));
            builder.Entity<IdentityRole>(entity =>
                entity.ToTable(name: "Roles"));
            builder.Entity<IdentityUserRole<string>>(entity =>
                entity.ToTable(name: "UserRoles"));
            builder.Entity<IdentityUserClaim<string>>(entity =>
                entity.ToTable(name: "UserClaim"));
            builder.Entity<IdentityUserLogin<string>>(entity =>
                entity.ToTable(name: "UserLogins"));
            builder.Entity<IdentityUserToken<string>>(entity =>
                entity.ToTable(name: "UserTokens"));
            builder.Entity<IdentityRoleClaim<string>>(entity =>
                entity.ToTable(name: "RoleClaim"));
            builder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
