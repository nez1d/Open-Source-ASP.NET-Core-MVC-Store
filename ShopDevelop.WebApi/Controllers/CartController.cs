using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.ShoppingCart.Command.Add;
using ShopDevelop.Application.Entities.ShoppingCart.Command.Clear;
using ShopDevelop.Application.Entities.ShoppingCart.Command.Remove;
using ShopDevelop.Application.Entities.ShoppingCart.Query.GetAll;
using ShopDevelop.Application.Entities.ShoppingCart.Query.GetByUserId;
using ShopDevelop.Application.Entities.ShoppingCart.Query.GetTotalPrice;
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
        string accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        var userId = jwtProvider.GetUserId(accessToken);
        
        var command = mapper.Map<AddToCartCommand>(model);
        command.UserId = userId;
        
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveFromCart(Guid id)
    {
        await Mediator.Send(new RemoveFromCartCommand()
        {
            ItemId = id
        });
        return NoContent();
    }
    
    [HttpDelete("{userId}")]
    public async Task<IActionResult> ClearCart(string userId)
    {
        await Mediator.Send(new ClearCartCommand()
        {
            UserId = userId
        });
        return NoContent();
    }
    
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetShoppingCart(Guid userId)
    {
        var items = await Mediator.Send(new GetShoppingCartItemsByUserIdQuery()
        {
            UserId = userId.ToString()
        });
        
        if(items is not null)
            return Ok(items);
        
        return NotFound();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await Mediator.Send(new GetAllCartItemsQuery());
        
        if(items is not null)
            return Ok(items);
        
        return NotFound();
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAllTotalValue(string userId)
    {
        var result = await Mediator.Send(new GetTotalShoppingCartPriceQuery()
        {
            UserId = userId
        });
        
        if(result is not null)
            return Ok(result);
        
        return NotFound();
    }
}