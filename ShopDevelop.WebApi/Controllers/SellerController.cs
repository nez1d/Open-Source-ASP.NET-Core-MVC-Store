using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Seller.Command.Create;
using ShopDevelop.Application.Entities.Seller.Command.Delete;
using ShopDevelop.Application.Entities.Seller.Command.Update;
using ShopDevelop.Application.Entities.Seller.Queries.GetAll;
using ShopDevelop.Application.Entities.Seller.Queries.GetById;
using ShopDevelop.Application.Entities.Seller.Queries.GetByName;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[ApiVersion(1, Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class SellerController : BaseController
{
    [HttpPost]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Create([FromBody] CreateSellerCommand createSellerCommand)
    {
        var result = await Mediator.Send(createSellerCommand);
        if(result is not 0)
            return Ok(result);
        
        return BadRequest();
    }

    [HttpPut]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Edit([FromBody] UpdateSellerCommand updateSellerCommand)
    {
        await Mediator.Send(updateSellerCommand);
        return NoContent();  
    }

    [HttpDelete("{id}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Delete(int id)
    {
        var request = new DeleteSellerCommand()
        {
            Id = id
        };
        await Mediator.Send(request);
        return NoContent();
    }
    
    [HttpGet]
    [MapToApiVersion(1)]
    public async Task<IActionResult> GetSellers()
    {
        var result = await Mediator
            .Send(new GetAllSellersListQuery());
        if(result is not null)
            return Ok(result);
        
        return NotFound();
    }
    
    [HttpGet("{id}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetSellerByIdQuery
        {
            Id = id
        };
        var result = await Mediator.Send(query);
        if(result is not null)
            return Ok(result);
        
        return NotFound();
    }

    [HttpGet("{name}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> GetByName(string name)
    {
        var query = new GetSellerByNameQuery()
        {
            Name = name
        };
        var result = await Mediator.Send(query);
        
        if(result is not null)
            return Ok(result);
        
        return NotFound();
    }
}