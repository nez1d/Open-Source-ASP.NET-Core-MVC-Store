using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Cart;
using ShopDevelop.Application.Services.Product;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CartController : BaseController
{
    private readonly ShoppingCartService shoppingCartService;
    private readonly IProductService productService;
    public CartController(ShoppingCartService shoppingCartService,
        IProductService productService) =>
        (this.shoppingCartService, this.productService) = (shoppingCartService, productService);
    
    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> GetShoppingCart()
    {
        var items = await shoppingCartService.GetShoppingCartItems();
        return Ok(items);
    }
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> AddToCart(Guid id, int amount)
    {
        var product = await productService.GetByIdAsync(id);
        await shoppingCartService.AddToCart(product, 1);
        return Ok();
    }
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> RemoveFromCart(Guid id)
    {
        var product = await productService.GetByIdAsync(id);
        await shoppingCartService.RemoveFromCart(product);
        return Ok();
    }
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> ClearCart()
    {
        /*await shoppingCartService.ClearCart();*/
        return Ok();
    }

    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> GetAllTotalValue()
    {
        /*await shoppingCartService.GetShoppingCartTotal();*/
        return Ok();
    }
}