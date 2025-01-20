using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Identity.DuendeServer.Data;

public class AuthDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>, IApplicationDbContext
{ 
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>(entity =>
            entity.ToTable(name: "AspNetUsers"));
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

        base.OnModelCreating(builder);
    }
    
    public async Task<int> SaveChangesAsync() 
    {
        return await base.SaveChangesAsync();
    }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Review> Reviews { get; set; }
}