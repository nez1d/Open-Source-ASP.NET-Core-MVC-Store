namespace ShopDevelop.Domain.Entities;

public class ShoppingCart
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } 
}