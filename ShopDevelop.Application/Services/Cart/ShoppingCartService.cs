using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Services.Cart;

public class ShoppingCartService : IShoppingCartService
{
    private IShoppingCartService shoppingCartService;
    public ShoppingCartService(IShoppingCartService shoppingCartService) =>
        this.shoppingCartService = shoppingCartService;

    

    
}
