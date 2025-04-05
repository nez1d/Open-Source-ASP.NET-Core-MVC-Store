using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class ShoppingCartRepository /*: IShoppingCartRepository*/
{
    public ApplicationDbContext context { get; set; }
    public ShoppingCartRepository(ApplicationDbContext context) =>
        this.context = context;
    
    /*public async Task<Guid> CreateShoppingCartAsync(ShoppingCart shoppingCart,
        CancellationToken cancellationToken)
    {
        var cart = await GetCartByUserIdAsync(shoppingCart.UserId, cancellationToken);
        
        if (cart is null || shoppingCart.Id == Guid.Empty)
            throw new NotFoundException(typeof(ShoppingCart), shoppingCart.Id);
        
        await context.ShoppingCarts.AddAsync(shoppingCart, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return shoppingCart.Id;
    }
    
    public async Task DeleteShoppingCartAsync(Guid shoppingCartId, 
        CancellationToken cancellationToken)
    {
        var cart = await GetCartAsync(shoppingCartId, cancellationToken);
        
        if (cart is null)
            throw new NotFoundException(typeof(ShoppingCart), shoppingCartId);
        
        context.ShoppingCarts.Remove(cart);
    }
    
    public async Task DeleteShoppingCartByUserIdAsync(string userId, 
        CancellationToken cancellationToken)
    {
        var cart = await GetCartByUserIdAsync(userId, cancellationToken);
        if (cart is null)
            throw new NotFoundException(typeof(ShoppingCart), userId);

        context.ShoppingCarts.Remove(cart);
    }
    
    public async Task AddToCartAsync(
        ShoppingCartItem shoppingCartItem, 
        CancellationToken cancellationToken)
    {
        await context.ShoppingCartItems
            .FirstOrDefaultAsync(item => 
                item.Product.Id == shoppingCartItem.Product.Id && 
                item.ShoppingCartId == shoppingCartItem.ShoppingCartId, 
                cancellationToken: cancellationToken);
    }
    
    public async Task RemoveFromCartAsync(Guid itemId, 
        CancellationToken cancellationToken)
    {
        var item = await context.ShoppingCartItems
            .FirstOrDefaultAsync(i => 
                i.Id == itemId, cancellationToken);
        
        if (item is null)
            throw new NotFoundException(typeof(ShoppingCartItem), itemId);
        
        context.ShoppingCartItems.Remove(item);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task ClearFromCartAsync(Guid shoppingCartId, CancellationToken cancellationToken)
    {
    }
    
    public async Task<ShoppingCart> GetCartAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var cart = await context.ShoppingCarts
            .FirstOrDefaultAsync(cart => cart.Id == id, cancellationToken);
        
        if (cart is null)
            throw new NotFoundException(typeof(ShoppingCart), id);
        
        return cart;
    }
    
    public async Task<ShoppingCart> GetCartByUserIdAsync(string userId, 
        CancellationToken cancellationToken)
    {
        var cart = await context.ShoppingCarts
            .FirstOrDefaultAsync(cart => 
                cart.UserId == userId, 
                cancellationToken
            );
        
        if (cart is null)
            throw new NotFoundException(typeof(ShoppingCart), userId);
        
        return cart;
    }*/
}