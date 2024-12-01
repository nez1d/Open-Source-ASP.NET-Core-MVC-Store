using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

            modelBuilder.Entity<ProductP>()
                .HasOne(f => f.Category)
                .WithMany(c => c.Products)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.Product);

            modelBuilder.Entity<UserM>()
                .HasIndex(user => user.Email)
                .IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserM> User { get; set; }
        public DbSet<ShoppingCartItem> ShopCartItems { get; set; }
        public DbSet<ProductP> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<DbSession> Sessions { get; set; }
    }
}
