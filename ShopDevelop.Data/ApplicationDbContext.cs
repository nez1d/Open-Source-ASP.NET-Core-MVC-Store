using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Data.Models;
/*using ShopDevelop.Data.Entity;*/

namespace ShopDevelop.Data.DataBase
{
    public class ApplicationDbContext : DbContext
                                      /*: IdentityDbContext<User, ApplicationRole, int>*/
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Order { get; set; }
    }

    
}
