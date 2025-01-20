using Microsoft.EntityFrameworkCore;
using ShopDevelop.Domain.Models;
namespace ShopDevelop.Domain.Interfaces
{
    public interface IApplicationDbContext 
    {
        DbSet<Seller> Sellers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductDetail> ProductDetails { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        DbSet<Review> Reviews { get; set; }
        Task<int> SaveChangesAsync();
    }
}