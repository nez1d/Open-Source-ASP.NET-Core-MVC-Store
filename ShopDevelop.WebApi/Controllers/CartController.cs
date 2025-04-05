using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.ShoppingCart.Command.Add;
using ShopDevelop.Application.Entities.ShoppingCart.Query.GetByUserId;
using ShopDevelop.Domain.Dto.ShoppingCart;
using ShopDevelop.Identity.DuendeServer.WebAPI.Data.IdentityConfigurations;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CartController(IMapper mapper, JwtProvider jwtProvider) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddToCart([FromBody] AddToCartDto model)
    {
        /*string accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        var userId = jwtProvider.GetUserId(accessToken);*/

        string userId = "f157e21c-381f-42e1-8363-18040eda0d00";
        
        var command = mapper.Map<AddToCartCommand>(model);
        command.UserId = userId;
        
        await Mediator.Send(command);
        return NoContent();
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
    
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetShoppingCart(Guid userId)
    {
        /*var items = await shoppingCartService.GetShoppingCartItems();*/
        var items = Mediator.Send(new GetShoppingCartItemsByUserIdQuery()
        {
            UserId = userId.ToString()
        });
        
        if(items is not null)
            return Ok(items);
        
        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTotalValue()
    {
        return Ok();
    }
}