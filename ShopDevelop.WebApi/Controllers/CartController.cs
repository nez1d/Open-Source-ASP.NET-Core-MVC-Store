using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Cart;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Domain.Models;
using ShopDevelop.Identity.DuendeServer.Data.IdentityConfigurations;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CartController : BaseController
{
    private readonly ShoppingCartService shoppingCartService;
    private readonly IProductService productService;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly JwtProvider jwtProvider;
    public CartController(ShoppingCartService shoppingCartService,
        IProductService productService,
        UserManager<ApplicationUser> userManager,
        JwtProvider jwtProvider) =>
        (this.shoppingCartService, this.productService, this.userManager,
            this.jwtProvider) = 
        (shoppingCartService, productService, userManager, 
            jwtProvider);
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> AddToCart(Guid id, int amount)
    {
        string accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        var userId = jwtProvider.GetUserId(accessToken);
        
        try
        {
            var product = await productService.GetByIdAsync(id);
            await shoppingCartService.AddToCart(product, 1, userId);
            return Ok();
        }
        catch { }
        return BadRequest();
    }
    
    [HttpDelete]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> RemoveFromCart(Guid id)
    {
        var product = await productService.GetByIdAsync(id);
        await shoppingCartService.RemoveFromCart(product);
        return Ok();
    }
    
    [HttpDelete]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> ClearCart()
    {
        /*await shoppingCartService.ClearCart();*/
        return Ok();
    }
    
    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> GetShoppingCart()
    {
        var items = await shoppingCartService.GetShoppingCartItems();
        return Ok(items);
    }

    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> GetAllTotalValue()
    {
        /*await shoppingCartService.GetShoppingCartTotal();*/
        return Ok();
    }
}