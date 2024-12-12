using AutoMapper;
using MediatR;
using ShopDevelop.Application.Entities.Category.Commands.Create;
using ShopDevelop.Domain.Models;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Application.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository categoryRepository;
    /*private readonly ISender mediator;*/
    private ICategoryService categoryService;

    public CategoryService(ICategoryRepository categoryRepository) =>
        this.categoryRepository = categoryRepository;
    
    public async Task<Guid> CreateCategoryAsync(string name, string description)
    {
        var category = new Domain.Models.Category
        {
            Name = name,
            Description = description,
            ImagePath = "/source/images/category.img"
        };
        /*try
        {
            var entity = await mediator.Send(new CreateCategoryCommand());
            return category.Id;
        }
        catch (Exception ex) { }
        
        return Guid.Empty;*/
        var result = await categoryRepository.Create(category);
        return category.Id;
    }

    public async Task EditCategoryAsync(Domain.Models.Category category)
    {
        var model = await categoryRepository.GetById(category.Id);
        await categoryRepository.Update(category);
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        await categoryRepository.Delete(id);
    }
    
    public Task<IEnumerable<Domain.Models.Category>> GetAllCategoryAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Models.Category> GetCategoryByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Models.Category>> GetAllCategory()
    {
        throw new NotImplementedException();
    }
}
