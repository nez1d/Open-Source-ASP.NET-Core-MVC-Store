namespace ShopDevelop.Domain.Models;

public class ShoppingCart
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
}