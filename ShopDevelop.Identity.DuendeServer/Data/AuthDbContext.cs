using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Identity.DuendeServer.Data;

public class AuthDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public AuthDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>(entity =>
            entity.ToTable(name: "Users"));
        builder.Entity<IdentityUserRole<string>>(entity =>
            entity.ToTable(name: "UserRoles"));
        builder.Entity<IdentityUserClaim<string>>(entity =>
            entity.ToTable(name: "UserClaim"));
        builder.Entity<IdentityUserLogin<string>>(entity =>
            entity.ToTable(name: "UserLogins"));
        builder.Entity<IdentityUserToken<string>>(entity =>
            entity.ToTable(name: "UserTockens"));
        builder.Entity<IdentityRoleClaim<string>>(entity =>
            entity.ToTable(name: "RoleClaim"));

        base.OnModelCreating(builder);
    }
}