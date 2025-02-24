using ShopDevelop.Application.Repository;

namespace ShopDevelop.Application.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository) =>
        this.categoryRepository = categoryRepository;
    
    public async Task<int> CreateCategoryAsync(string name, string description)
    {
        /*var category = new Domain.Entities.Category
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
        
        return Guid.Empty;#1#
        var result = await categoryRepository.Create(category);
        return category.Id;*/
        return 0;
    }

    public async Task EditCategoryAsync(Domain.Entities.Category category)
    {
        /*var model = await categoryRepository.GetById(category.Id);
        await categoryRepository.Update(category);*/
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        /*await categoryRepository.Delete(id);*/
    }
    
    public Task<IEnumerable<Domain.Entities.Category>> GetAllCategoryAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Category> GetCategoryByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    
    public async Task<Domain.Entities.Category> GetByName(string name)
    {
        var category = await categoryRepository.GetByName(name);
        
        if (category != null)
            return category;
        
        return null;
    }

    public Task<IEnumerable<Domain.Entities.Category>> GetAllCategory()
    {
        throw new NotImplementedException();
    }
}
