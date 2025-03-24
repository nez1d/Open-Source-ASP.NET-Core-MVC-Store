using Microsoft.EntityFrameworkCore;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class ShoppingCartRepository
{
    public ApplicationDbContext context { get; set; }

    public ShoppingCartRepository(ApplicationDbContext context) =>
        this.context = context;
    
    
    public async Task CreateShoppingCartAsync()
    {
    }
    
    public async Task DeleteShoppingCartAsync()
    {
    }
    
    public async Task AddToCartAsync(ShoppingCartItem shoppingCartItem)
    {
        var result = await context.ShoppingCartItems
            .SingleOrDefaultAsync(item => 
                item.Product.Id == shoppingCartItem.Product.Id && 
                item.ShoppingCartId == shoppingCartItem.ShoppingCartId
            );
    }
    
    public async Task RemoveFromCartAsync()
    {
    }
    
    public async Task ClearFromCartAsync()
    {
    }
    
    public async Task<ShoppingCart> GetCartAsync()
    {
        return new ShoppingCart();
    }
    
}