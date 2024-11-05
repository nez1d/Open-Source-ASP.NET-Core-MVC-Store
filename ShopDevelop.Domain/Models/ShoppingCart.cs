using Microsoft.Extensions.DependencyInjection;

namespace ShopDevelop.Domain.Models;

public class ShoppingCart
{
    /*private readonly ApplicationDbContext context;
    public ShoppingCart(ApplicationDbContext context) =>
        this.context = context;

    public Guid ShoppingCartId { get; set; }*/

    public IEnumerable<ShoppingCartItem> shoppingCartItems { get; set; }

    public static ShoppingCart GetCart(IServiceCollection services)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddToCart(Product product, int amount)
    {
        throw new NotImplementedException();
    }

    public Task<int> RemoveFromCart(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems()
    {
        throw new NotImplementedException();
    }

    public Task ClearCart()
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetShoppingCartTotal()
    {
        throw new NotImplementedException();
    }
}