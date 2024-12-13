using Microsoft.EntityFrameworkCore;
using ShopDevelop.Domain.Models;
namespace ShopDevelop.Domain.Interfaces
{
    public interface IApplicationDbContext 
    {
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<Seller> Sellers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductDetail> ProductDedails { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        DbSet<Review> Reviews { get; set; }
        Task<int> SaveChangesAsync();
    }
}