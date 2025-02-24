/*
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Application.Services.Cart;

public class ShoppingCartService 
{
    private readonly IApplicationDbContext context;
    public ShoppingCartService(IApplicationDbContext context) =>
            (this.context) = (context);
    
    public Guid ShoppingCartId { get; set; }

    public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
    
    public static ShoppingCartService GetCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
        
        var context = services.GetService<IApplicationDbContext>();
        string cartId = session.GetString("CartId") 
            ?? Guid.NewGuid().ToString();

        session.SetString("CartId", cartId);
        return new ShoppingCartService(context) 
            { ShoppingCartId = Guid.Parse(cartId) };
    }
    
    public async Task<bool> AddToCart(
        Domain.Entities.Product product, 
        int amount, 
        string userId)
    {
        if(product.InStock == 0 || amount == 0)
            return false;
        
        var shoppingCartItem = context.ShoppingCartItems.SingleOrDefault(
            item => item.Product.Id == product.Id && 
                item.ShoppingCartId == ShoppingCartId);

        var isValidAmount = true;

        if(shoppingCartItem == null){
            if(amount > product.InStock)
                isValidAmount = false;
            
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = ShoppingCartId,
                Product = product,
                Amount = (uint)Math.Min(product.InStock, amount),
                ApplicationUserId = userId
            };
            context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            if(product.InStock - shoppingCartItem.Amount - amount >= 0)
            {
                shoppingCartItem.Amount += (uint)amount;
            }
            else
            {
                shoppingCartItem.Amount += (product.InStock - shoppingCartItem.Amount);
                isValidAmount = false;
            }
        }
        await context.SaveChangesAsync();
        return isValidAmount;
    }

    public async Task<bool> RemoveFromCart(Domain.Entities.Product product)
    {
        var shoppingCartItem = await context.ShoppingCartItems
            .SingleOrDefaultAsync(s => s.Product.Id == product.Id 
                && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
            return false;
        
        context.ShoppingCartItems.Remove(shoppingCartItem);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task ClearCart(Guid ShoppingCartId)
    {
        var item = context
            .ShoppingCartItems.Where(cart => 
                cart.ShoppingCartId == ShoppingCartId);

        context.ShoppingCartItems.RemoveRange(item);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems(/*string userId#1#)
    {
        return ShoppingCartItems = context.ShoppingCartItems
                   .Where(c => c.ShoppingCartId == ShoppingCartId)
                   .Include(s => s.Product);
        
        /*return context.ShoppingCartItems
            .Where(item => item.ApplicationUserId == userId);#1#
    }

    public async Task<decimal> GetShoppingCartTotal(Guid ShoppingCartId)
    {
        return await context.ShoppingCartItems.Where(cart =>
                cart.ShoppingCartId == ShoppingCartId)
            .Select(cart => cart.Product.Price * cart.Amount)
            .SumAsync();
    }
}
*/
