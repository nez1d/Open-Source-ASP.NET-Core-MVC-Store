using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Cart;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CartController : BaseController
{
    private readonly IShoppingCartRepository repository;
    public CartController(IShoppingCartRepository repository) =>
        this.repository = repository;
    
    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> GetShoppingCart()
    {
        var items = await repository.GetShoppingCartItems();
        return Ok(items);
    }
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> ClearCart()
    {
        return Ok();
    }
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> RemoveFromCart(Guid id)
    {
        return Ok();
    }
}