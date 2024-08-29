using Microsoft.EntityFrameworkCore;
using ShopDevelop.Data.Configurations;
using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.Product);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<ShoppingCartItem> ShopCartItems { get; set; }
        public DbSet<ShoppingCart> ShopCart { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<DbSession> Sessions { get; set; }
    }
}
