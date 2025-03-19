using Microsoft.AspNetCore.Mvc;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CartController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddToCart(Guid id, int amount)
    {
        /*string accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        var userId = jwtProvider.GetUserId(accessToken);
        
        try
        {
            var product = await productService.GetByIdAsync(id);
            await shoppingCartService.AddToCart(product, 1, userId);
            return Ok();
        }
        catch { }
        return BadRequest();*/
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveFromCart(Guid id)
    {
        /*var product = await productService.GetByIdAsync(id);
        await shoppingCartService.RemoveFromCart(product);*/
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> ClearCart()
    {
        /*await shoppingCartService.ClearCart();*/
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetShoppingCart()
    {
        /*var items = await shoppingCartService.GetShoppingCartItems();*/
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTotalValue()
    {
        return Ok();
    }
}