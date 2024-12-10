using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.Repository;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly ApplicationDbContext context;
    public ShoppingCartRepository(ApplicationDbContext context) =>
            (this.context) = (context);
    
    public Guid SCId { get; set; }

    public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
    
    public static ShoppingCart GetCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = services.GetService<ApplicationDbContext>();
        string cartId = session.GetString(".AspNetCore.Cookies-Session") ?? Guid.NewGuid().ToString();
        
        session.SetString(".AspNetCore.Cookies-Session", cartId);

        return new ShoppingCart() { ShoppingCartId = cartId }; 
    }
    
    public async Task<bool> AddToCart(Guid ShoppingCartId, Product product, int amount)
    {
        if(product.InStock == 0 || amount == 0)
        {
            return false;
        }

        var shoppingCartItem = context.ShoppingCartItems.SingleOrDefault(
            item => item.Product.Id == product.Id && 
                    item.ShoppingCartId == ShoppingCartId);

        var isValidAmount = true;

        if(shoppingCartItem == null){
            if(amount > product.InStock)
            {
                isValidAmount = false;
            }
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = ShoppingCartId,
                Product = product,
                Amount = (uint)Math.Min(product.InStock, amount)
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

    public Task<uint> RemoveFromCart(Product product)
    {
        throw new NotImplementedException();
    }

    public Task ClearCart(Guid ShoppingCartId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems()
    {
        return ShoppingCartItems ??
               (ShoppingCartItems = context.ShoppingCartItems
                   .Where(c => c.ShoppingCartId == SCId)
                   .Include(s => s.Product));
    }

    public Task<decimal> GetShoppingCartTotal(Guid ShoppingCartId)
    {
        throw new NotImplementedException();
    }

    /*public async Task<uint> RemoveFromCart(Product product)
    {
        var cart = GetCart(serviceProvider);
        
        var shoppingCartItem = context.ShoppingCartItems
            .SingleOrDefault(item => item.Product.Id == product.Id
                && item.ShoppingCartId.ToString() == cart.ShoppingCartId);
        
        uint amount = 0;
        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                amount = shoppingCartItem.Amount;
            }
            else
            {
                context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }
        await context.SaveChangesAsync();
        return amount;
    }
    
    public async Task ClearCart(Guid ShoppingCartId)
    {
        var item = context
            .ShoppingCartItems.Where(cart => 
                cart.ShoppingCartId == ShoppingCartId);

        context.ShoppingCartItems.RemoveRange(item);
        await context.SaveChangesAsync();
    }

    public async Task<decimal> GetShoppingCartTotal(Guid ShoppingCartId)
    {
        return await context.ShoppingCartItems.Where(cart =>
                cart.ShoppingCartId == ShoppingCartId)
            .Select(cart => cart.Product.Price * cart.Amount)
            .SumAsync();
    }*/
}