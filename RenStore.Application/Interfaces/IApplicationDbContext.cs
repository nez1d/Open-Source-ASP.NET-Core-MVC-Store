using Microsoft.EntityFrameworkCore;
using RenStore.Domain.Entities;
using RenStore.Domain.Entities.Products;

namespace RenStore.Application.Interfaces;

public interface IApplicationDbContext 
{
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
    Task<int> SaveChangesAsync();
}