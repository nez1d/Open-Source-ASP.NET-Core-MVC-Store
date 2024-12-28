using ShopDevelop.Domain.Enums;

namespace ShopDevelop.Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public uint Amount { get; set; } 
    public string ZipCode { get; set; }
    public DeliveryStatus Status { get; set; }
    public decimal OrderTotal { get; set; }
    public DateTime CreatedDate { get; set; }
    public ApplicationUser User { get; set; }
    public Guid UserId { get; set; }
    public Product Product { get; set; }
    public Guid ProductId { get; set; }
}