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
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class OrderController(IMapper mapper, JwtProvider jwtProvider) : BaseController
{
    [HttpPost]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Create([FromBody] CreateOrderDto model)
    {
        string accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        var userId = jwtProvider.GetUserId(accessToken);
        
        var command = mapper.Map<CreateOrderCommand>(model);
        command.ApplicationUserId = userId;
        
        var result = await Mediator.Send(command);
        if(result != Guid.Empty)
            return Ok(result);
        
        return BadRequest();
    }
    
    [HttpPut]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Edit([FromBody] UpdateOrderDto updateOrderDto)
    {
        var command = mapper.Map<UpdateOrderCommand>(updateOrderDto);
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [MapToApiVersion(1)]
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
    public async Task<IActionResult> GetAll()
    {
        var result = await Mediator.Send(new GetAllOrdersQuery());
        
        if(result is not null)
            return Ok(result);
        
        return NotFound();
    }
    
    [HttpGet("{id}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await Mediator.Send(new GetOrderByIdQuery() { Id = id });
        if(result is not null)
            return Ok(result);
        
        return NotFound();
    }
    
    [HttpGet("{id}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> GetAllByUserId(string id)
    {
        var result = await Mediator.Send(
            new GetOrdersByUserIdQuery()
            {
                UserId = id
            });
        
        if(result is not null)
            return Ok(result);
        
        return NotFound();
    }
    
    [HttpGet("{id}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> GetAllByProductId(Guid id)
    {
        var result = await Mediator.Send(
            new GetOrdersByProductIdQuery()
            {
                ProductId = id
            });
        
        if(result is not null)
            return Ok(result);
        
        return NotFound();
    }
}