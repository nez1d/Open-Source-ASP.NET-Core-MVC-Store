using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Entities.Products;
using ShopDevelop.Persistence.EntityTypeConfigurations;

namespace ShopDevelop.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductDetailConfiguration());
        modelBuilder.ApplyConfiguration(new ClothesProductConfiguration());
        modelBuilder.ApplyConfiguration(new ShoesProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new SellerConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingCartItemConfiguration());

        base.SaveChangesAsync();
        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> SaveChangesAsync() 
    {
        return await base.SaveChangesAsync();
    }
    
    public DbSet<ApplicationUser> AspNetUsers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<ClothesProduct> ClothesProducts { get; set; }
    public DbSet<ShoesProduct> ShoesProducts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
}
