using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Orders.Commands.Create;
using ShopDevelop.Application.Entities.Orders.Commands.Delete;
using ShopDevelop.Application.Entities.Orders.Commands.Update;
using ShopDevelop.Application.Entities.Orders.Queries.GetAll;
using ShopDevelop.Application.Entities.Orders.Queries.GetById;
using ShopDevelop.Application.Entities.Orders.Queries.GetByProductId;
using ShopDevelop.Application.Entities.Orders.Queries.GetByUserId;
using ShopDevelop.Domain.Dto.Order;
using ShopDevelop.Identity.DuendeServer.WebAPI.Data.IdentityConfigurations;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[ApiVersion(1, Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
public class OrderController(IMapper mapper, JwtProvider jwtProvider) : BaseController
{
    [HttpPost]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/order")]
    public async Task<IActionResult> Create([FromBody] CreateOrderDto model)
    {
        string? accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        if(accessToken == null)
            return Unauthorized();
        
        var userId = jwtProvider.GetUserId(accessToken);
        
        var command = mapper.Map<CreateOrderCommand>(model);
        command.ApplicationUserId = userId;
        
        var result = await Mediator.Send(command);
        if(result == Guid.Empty)
            return BadRequest();
        
        return Ok(result);
    }
    
    [HttpPatch]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/order/{id:int}")]
    public async Task<IActionResult> Edit([FromBody] UpdateOrderDto updateOrderDto)
    {
        var command = mapper.Map<UpdateOrderCommand>(updateOrderDto);
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/order/{id:int}")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        await Mediator.Send(new DeleteOrderCommand()
        {
            OrderId = id
        });
        return NoContent();
    }

    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/orders")]
    public async Task<IActionResult> GetAll()
    {
        var result = await Mediator.Send(new GetAllOrdersQuery());
        
        if(result is null)
            return NotFound();
            
        return Ok(result);
    }
    
    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/order/{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await Mediator.Send(new GetOrderByIdQuery() { Id = id });
        
        if(result is null)
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/user-orders/{userId}")]
    public async Task<IActionResult> GetAllByUserId(string userId)
    {
        var result = await Mediator.Send(
            new GetOrdersByUserIdQuery()
            {
                UserId = userId
            });
        
        if(result is null)
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/product-orders/{productId:guid}")]
    public async Task<IActionResult> GetAllByProductId(Guid productId)
    {
        var result = await Mediator.Send(
            new GetOrdersByProductIdQuery()
            {
                ProductId = productId
            });
        
        if(result is null)
            return NotFound();
        
        return Ok(result);
    }
}