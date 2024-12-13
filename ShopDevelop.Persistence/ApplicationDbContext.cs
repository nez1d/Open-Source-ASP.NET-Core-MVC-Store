using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Domain.Models;
using ShopDevelop.Persistence.EntityTypeConfigurations;

namespace ShopDevelop.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private IApplicationDbContext _iApplicationDbContextImplementation;
    /*private readonly IConfiguration _configuration;
    public ApplicationDbContext(IConfiguration configuration) =>
        _configuration = configuration;*/
    
    public ApplicationDbContext(DbContextOptions options)
        : base(options) { }

    /*protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        /*builder.UseNpgsql(_configuration
            .GetConnectionString("DefaultConnection"))
            .UseLoggerFactory(CreateLoggerFactory())
            .EnableSensitiveDataLogging();#1#
    }*/

    public ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => { builder.AddConsole(); });

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductDetailConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguraion());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingCartItemConfiguration());*/
        base.SaveChangesAsync();
        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDedails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Review> Reviews { get; set; }
}
