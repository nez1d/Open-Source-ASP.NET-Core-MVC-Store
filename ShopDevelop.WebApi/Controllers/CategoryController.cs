using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Domain.Models;
using ShopDevelop.WebApi.ViewModels;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]/{id?}")]
[ApiController]
public class CategoryController : BaseController
{
    private readonly ICategoryService categoryService;
    public CategoryController(ICategoryService categoryService) =>
        this.categoryService = categoryService;


    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> CreateCategory(CategoryViewModel model)
    {
        /*var category = await categoryService.CreateCategoryAsync(model);
        
        return Ok(category);*/

        return BadRequest();  
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> EditCategory(Category model)
    {
        await categoryService.EditCategoryAsync(model);
        
        return Ok();  
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var Category = categoryService.DeleteCategoryAsync(id);

        return Ok();
    }
}