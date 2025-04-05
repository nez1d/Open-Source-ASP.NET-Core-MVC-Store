using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace ShopDevelop.Domain.Entities;

public class ApplicationUser : IdentityUser, IUser<string>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Role { get; set; } 
    public string? Country { get; set; } 
    public string? City { get; set; } 
    public double? Balance { get; set; } 
    public bool? IsActive { get; set; } 
    public DateTime? CreatedDate { get; set; }
    public string? ImagePath { get; set; } 
    public string? ImageFooterPath { get; set; } 
    public IEnumerable<Review>? Reviews { get; set; }
    public IEnumerable<ShoppingCartItem>? ShoppingCartItems { get; set; }
    public IEnumerable<Order>? Orders { get; set; }
}