using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Application.Services.Cart;

public class ShoppingCartService 
{
    /*private readonly IApplicationDbContext context;
    private readonly IShoppingCartRepository shoppingCartRepository;
    private readonly UserManager<ApplicationUser> userManager;
    public ShoppingCartService(IApplicationDbContext context,
        IShoppingCartRepository shoppingCartRepository,
        UserManager<ApplicationUser> userManager) =>
            (this.context, this.shoppingCartRepository, this.userManager) = 
            (context, shoppingCartRepository, userManager);
    
    public Guid ShoppingCartId { get; set; }

    public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
    
    /*public static ShoppingCartService GetCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
        
        var context = services.GetService<IApplicationDbContext>();
        string cartId = session.GetString("CartId")
        if (cartId is null || cartId == Guid.Empty.ToString())
        {
            CreateCartAsync();
        }

        session.SetString("CartId", cartId);
        
        return new ShoppingCartService(context)
        {
            ShoppingCartId = Guid.Parse(cartId)
        };
    }#1#

    public async Task<ShoppingCart> GetCartAsync(Guid shoppingCartId)
    {
       return await shoppingCartRepository.GetCartAsync(shoppingCartId, CancellationToken.None);
    }

    public async Task CreateCartAsync(string userId)
    {
        var cart = await shoppingCartRepository.GetCartByUserIdAsync(userId, CancellationToken.None);

        if (cart is null)
            await shoppingCartRepository
                .CreateShoppingCartAsync(
                    new ShoppingCart
                    {
                        UserId = userId,
                    }, 
                    CancellationToken.None);
    }
    
    /*public async Task<ShoppingCart> GetOrCreateCartAsync(string cartId)
    {
        var cart = await _context.ShoppingCarts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.CartId == cartId);

        if (cart == null)
        {
            cart = new ShoppingCart { CartId = cartId };
            _context.ShoppingCarts.Add(cart);
            await _context.SaveChangesAsync();
        }

        return cart;
    }

    public async Task AddItemToCartAsync(string cartId, string productName, int quantity, decimal price)
    {
        var cart = await GetOrCreateCartAsync(cartId);

        var existingItem = cart.Items.FirstOrDefault(i => i.ProductName == productName);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            cart.Items.Add(new CartItem
            {
                ProductName = productName,
                Quantity = quantity,
                Price = price,
                ShoppingCartId = cart.Id
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task RemoveItemFromCartAsync(string cartId, string productName)
    {
        var cart = await GetOrCreateCartAsync(cartId);

        var itemToRemove = cart.Items.FirstOrDefault(i => i.ProductName == productName);
        if (itemToRemove != null)
        {
            cart.Items.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<CartItem>> GetCartItemsAsync(string cartId)
    {
        var cart = await GetOrCreateCartAsync(cartId);
        return cart.Items;
    }#1#
    
    /*public async Task<bool> AddToCart(
        Domain.Entities.Product product, 
        int amount, 
        string userId)
    {
        if(product.InStock == 0 || amount == 0)
            return false;
        
        var shoppingCartItem = context.ShoppingCartItems
            .SingleOrDefault(item => 
                item.Product.Id == product.Id && 
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
                ApplicationUserId = Guid.Parse(userId)
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
    }#1#

    /*public async Task<bool> RemoveFromCart(Domain.Entities.Product product)
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
    }#1#

    public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems(Guid cartId)
    {
        return ShoppingCartItems = context.ShoppingCartItems
                   .Where(c => c.ShoppingCartId == cartId)
                   .Include(s => s.Product);
    }
    public async Task<decimal> GetShoppingCartTotal(Guid cartId)
    {
        return await context.ShoppingCartItems.Where(cart =>
                cart.ShoppingCartId == cartId)
            .Select(cart => cart.Product.Price * cart.Amount)
            .SumAsync();
    }*/
}
