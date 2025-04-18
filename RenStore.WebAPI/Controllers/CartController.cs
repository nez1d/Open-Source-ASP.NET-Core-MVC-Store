using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RenStore.Application.Entities.ShoppingCart.Command.Add;
using RenStore.Application.Entities.ShoppingCart.Command.Clear;
using RenStore.Application.Entities.ShoppingCart.Command.Remove;
using RenStore.Application.Entities.ShoppingCart.Query.GetAll;
using RenStore.Application.Entities.ShoppingCart.Query.GetByUserId;
using RenStore.Application.Entities.ShoppingCart.Query.GetTotalPrice;
using RenStore.Domain.Dto.ShoppingCart;
using RenStore.Identity.DuendeServer.WebAPI.Data.IdentityConfigurations;

namespace RenStore.WebApi.Controllers;

[ApiController]
[ApiVersion(1, Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
public class CartController(IMapper mapper, JwtProvider jwtProvider) : BaseController
{
    [HttpPost]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/add-to-cart/{productId:guid}/{amount:int}")]
    public async Task<IActionResult> AddToCart(Guid productId, int amount = 1)
    {
        string? accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        if(accessToken is null)
            return Unauthorized();
        
        var userId = jwtProvider.GetUserId(accessToken);
        
        var command = mapper.Map<AddToCartCommand>(
            new AddToCartDto
            {
                ProductId = productId, 
                Amount = amount
            });
        
        command.UserId = userId;
        
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/cart/{id:guid}/{amount:int}")]
    public async Task<IActionResult> RemoveFromCart(Guid id, int amount = 1)
    {
        await Mediator.Send(new RemoveFromCartCommand()
        {
            ItemId = id,
            Amount = (uint)amount
        });
        return NoContent();
    }
    
    [HttpDelete]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/clear-cart")]
    public async Task<IActionResult> Clear()
    {
        string? accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        if(accessToken is null)
            return Unauthorized();
        
        var userId = jwtProvider.GetUserId(accessToken);
        
        await Mediator.Send(new ClearCartCommand()
        {
            UserId = userId
        });
        return NoContent();
    }
    
    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/cart-items")]
    public async Task<IActionResult> GetAll()
    {
        var result = await Mediator.Send(new GetAllCartItemsQuery());
        
        if(!result.Any())
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/user-items")]
    public async Task<IActionResult> GetByUserId()
    {
        string? accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        if(accessToken is null)
            return Unauthorized();
        
        var userId = jwtProvider.GetUserId(accessToken);
        
        var result = await Mediator.Send(
            new GetShoppingCartItemsByUserIdQuery()
            {
                UserId = userId
            });
        
        if(!result.Any())
            return NotFound();
        
        return Ok(result);
    }

    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/cart-total")]
    public async Task<IActionResult> GetTotal()
    {
        string? accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        if(accessToken is null)
            return Unauthorized();
        
        var userId = jwtProvider.GetUserId(accessToken);
        
        var result = await Mediator.Send(
            new GetTotalShoppingCartPriceQuery()
            {
                UserId = userId
            });
        
        if(result is null)
            return NotFound(); 
        
        return Ok(result);
    }
}