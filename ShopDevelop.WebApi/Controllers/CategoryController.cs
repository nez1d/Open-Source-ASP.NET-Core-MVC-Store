using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Domain.Entities;


namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CategoryController : BaseController
{
    private readonly ICategoryService categoryService;
    public CategoryController(ICategoryService categoryService) =>
        (this.categoryService) = (categoryService);

    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> CreateCategory(string name, string description)
    {
        await categoryService.CreateCategoryAsync(name, description);
        return Ok();
    }

    /*[HttpPatch]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> EditCategory(Category model)
    {
        await categoryService.EditCategoryAsync(model);
        return Ok();  
    }

    [HttpDelete]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        await categoryService.DeleteCategoryAsync(id);
        return Ok();
    }*/
}