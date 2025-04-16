using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Seller.Command.Create;
using ShopDevelop.Application.Entities.Seller.Command.Delete;
using ShopDevelop.Application.Entities.Seller.Command.Update;
using ShopDevelop.Application.Entities.Seller.Queries.GetAll;
using ShopDevelop.Application.Entities.Seller.Queries.GetById;
using ShopDevelop.Application.Entities.Seller.Queries.GetByName;
using ShopDevelop.Domain.Dto.Seller;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[ApiVersion(1, Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
public class SellerController(IMapper mapper) : BaseController
{
    [HttpPost]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/seller")]
    public async Task<IActionResult> Create([FromBody] CreateSellerDto dto)
    {
        var command = mapper.Map<CreateSellerCommand>(dto);
        var result = await Mediator.Send(command);
        
        if(result is not 0)
            return Ok(result);
        
        return BadRequest();
    }
    
    [HttpPatch]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/seller/{id:int}")]
    public async Task<IActionResult> Edit(int id, [FromBody] UpdateSellerDto dto)
    {
        var seller = await Mediator.Send(new GetSellerByIdQuery() { Id = id });
        
        if (seller is null)
            return BadRequest();

        var command = mapper.Map<UpdateSellerCommand>(dto);
        command.Id = id;
        
        await Mediator.Send(command);
        return NoContent();  
    }

    [HttpDelete]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/seller/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var request = new DeleteSellerCommand() { Id = id };
        await Mediator.Send(request);
        return NoContent();
    }
    
    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/sellers")]
    public async Task<IActionResult> GetAll()
    {
        var result = await Mediator
            .Send(new GetAllSellersListQuery());
        
        if(!result.Any())
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/seller/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetSellerByIdQuery { Id = id };
        var result = await Mediator.Send(query);
        
        if(result is null)
            return NotFound();
        
        return Ok(result);
    }

    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/seller/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var query = new GetSellerByNameQuery() { Name = name };
        var result = await Mediator.Send(query);
        
        if(result is null)
            return NotFound();
        
        return Ok(result);
    }
}