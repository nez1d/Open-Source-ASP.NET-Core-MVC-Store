namespace ShopDevelop.Domain.Models;

public class ShoppingCart
{
    public string ShoppingCartId { get; set; }

    public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
}