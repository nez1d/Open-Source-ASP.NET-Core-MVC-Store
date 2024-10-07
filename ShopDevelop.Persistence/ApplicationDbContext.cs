using Microsoft.EntityFrameworkCore;
using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Domain.Models;
using ShopDevelop.Persistence.EntityTypeConfigurations;

namespace ShopDevelop.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
