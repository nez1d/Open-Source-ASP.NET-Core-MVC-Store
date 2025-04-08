using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Category.Commands.Create;
using ShopDevelop.Application.Entities.Category.Commands.Delete;
using ShopDevelop.Application.Entities.Category.Commands.Update;
using ShopDevelop.Application.Entities.Category.Queries.GetAllCategories;
using ShopDevelop.Application.Entities.Category.Queries.GetCategoryById;
using ShopDevelop.Application.Entities.Category.Queries.GetCategoryByName;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[ApiVersion(1, Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class CategoryController : BaseController
{
    [HttpPost]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        var result = await Mediator.Send(command);
        if (result != 0)
            return Created();
        
        return BadRequest();
    }

    [HttpPut]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Edit([FromBody] UpdateCategoryCommand model)
    {
        await Mediator.Send(model); 
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MapToApiVersion(1)]
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
    public async Task<IActionResult> Get()
    {
        var result = await Mediator
            .Send(new GetCategoriesListQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await Mediator.Send(
            new GetCategoryByIdQuery()
            {
                Id = id
            });
        return Ok(result);
    }
    
    [HttpGet("{name}")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Get(string name)
    {
        var result = await Mediator.Send(
            new GetCategoryByNameQuery()
            {
                Name = name
            });
        return Ok(result);
    }
}