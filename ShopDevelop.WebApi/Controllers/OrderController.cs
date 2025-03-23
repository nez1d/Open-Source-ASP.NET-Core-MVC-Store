using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Orders.Commands.Create;
using ShopDevelop.Application.Entities.Orders.Commands.Delete;
using ShopDevelop.Application.Entities.Orders.Queries.GetAll;
using ShopDevelop.Application.Entities.Orders.Queries.GetById;
using ShopDevelop.Application.Entities.Orders.Queries.GetByProductId;
using ShopDevelop.Application.Entities.Orders.Queries.GetByUserId;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]/")]
[ApiController]
public class OrderController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand createOrderCommand)
    {
        var result = await Mediator.Send(createOrderCommand);
        if(result != Guid.Empty)
            return Ok(result);
        
        return BadRequest();
    }
    
    [HttpPut]
    public async Task<IActionResult> Edit()
    {
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        await Mediator.Send(new DeleteOrderCommand()
        {
            OrderId = id
        });
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await Mediator.Send(new GetAllOrdersQuery());
        
        if(result is not null)
            return Ok(result);
        
        return NotFound();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await Mediator.Send(new GetOrderByIdQuery() { Id = id });
        if(result is not null)
            return Ok(result);
        
        return NotFound();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllByUserId(Guid id)
    {
        var result = await Mediator.Send(
            new GetOrdersByUserIdQuery() { UserId = id });
        
        if(result is not null)
            return Ok(result);
        
        return NotFound();
    }
    
    [HttpGet("{id}")]
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