using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Category.Commands.Create;
using ShopDevelop.Application.Entities.Category.Commands.Delete;
using ShopDevelop.Application.Entities.Category.Commands.Update;
using ShopDevelop.Application.Entities.Category.Queries.GetAllCategories;
using ShopDevelop.Application.Entities.Category.Queries.GetCategoryById;
using ShopDevelop.Application.Entities.Category.Queries.GetCategoryByName;
using ShopDevelop.Domain.Dto.Category;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[ApiVersion(1, Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
public class CategoryController(IMapper mapper) : BaseController
{
    [HttpPost]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/category")]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
    {
        var command = mapper.Map<CreateCategoryCommand>(dto);
        var result = await Mediator.Send(command);
        
        if (result != 0)
            return Created();
        
        return BadRequest();
    }

    [HttpPatch]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/category/{id:int}")]
    public async Task<IActionResult> Edit(int id, [FromBody] UpdateCategoryDto dto)
    {
        var category = await Mediator.Send(new GetCategoryByIdQuery() { Id = id });
        
        if (category is null)
            return BadRequest();
        
        var command = mapper.Map<UpdateCategoryCommand>(dto);
        command.Id = id;
        
        await Mediator.Send(command); 
        return NoContent();
    }

    [HttpDelete]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/category/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(
            new DeleteCategoryCommand
            {
                Id = id
            });
        return NoContent();
    }
    
    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/categories")]
    public async Task<IActionResult> GetAll()
    {
        var result = await Mediator
            .Send(new GetCategoriesListQuery());
        
        if (!result.Any())
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/category/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await Mediator.Send(
            new GetCategoryByIdQuery()
            {
                Id = id
            });
        
        if (result is null)
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/category/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var result = await Mediator.Send(
            new GetCategoryByNameQuery()
            {
                Name = name
            });
        
        if (result is null)
            return NotFound();
        
        return Ok(result);
    }
}