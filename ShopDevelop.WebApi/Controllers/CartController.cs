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
    private readonly IShoppingCartRepository repository;
    private readonly IProductService productService;
    public CartController(IShoppingCartRepository repository,
        IProductService productService) =>
        (this.repository, this.productService) = (repository, productService);
    
    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> GetShoppingCart()
    {
        var items = await repository.GetShoppingCartItems();
        return Ok(items);
    }
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> AddToCart(Guid id, int amount)
    {
        var product = await productService.GetByIdAsync(id);
        await repository.AddToCart(product, 1);
        return Ok();
    }
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> RemoveFromCart(Guid id)
    {
        var product = await productService.GetByIdAsync(id);
        await repository.RemoveFromCart(product);
        return Ok();
    }
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> ClearCart()
    {
        return Ok();
    }
}