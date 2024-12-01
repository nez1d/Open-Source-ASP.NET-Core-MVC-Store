using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace ShopDevelop.Domain.Models;

public class ApplicationUser : IdentityUser, IUser<string>
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
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
    public IEnumerable<ShoppingCartItem>? CartItems { get; set; }
    public IEnumerable<Order>? Orders { get; set; }
    public Guid? OrderId { get; set; }
}