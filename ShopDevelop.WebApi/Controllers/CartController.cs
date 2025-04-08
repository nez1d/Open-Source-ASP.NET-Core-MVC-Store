using Asp.Versioning;
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
[ApiVersion(1, Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class CartController(IMapper mapper, JwtProvider jwtProvider) : BaseController
{
    [HttpPost]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Add([FromBody] AddToCartDto model)
    {
        string accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        var userId = jwtProvider.GetUserId(accessToken);
        
        var command = mapper.Map<AddToCartCommand>(model);
        command.UserId = userId;
        
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Remove(Guid id)
    {
        await Mediator.Send(new RemoveFromCartCommand()
        {
            ItemId = id
        });
        return NoContent();
    }
    
    [HttpDelete("{userId}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Clear(string userId)
    {
        await Mediator.Send(new ClearCartCommand()
        {
            UserId = userId
        });
        return NoContent();
    }
    
    [HttpGet("{userId}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Get(Guid userId)
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
    [MapToApiVersion(1)]
    public async Task<IActionResult> Get()
    {
        var items = await Mediator.Send(new GetAllCartItemsQuery());
        
        if(items is not null)
            return Ok(items);
        
        return NotFound();
    }

    [HttpGet("{userId}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> GetTotal(string userId)
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