namespace ShopDevelop.Application.Services.Category;

public interface ICategoryService
{
    Task<Guid> CreateCategory(Domain.Models.Category category);
    Task EditCategory(Guid id);
    Task DeleteCategory(Guid id);
    Task<Domain.Models.Category> GetCategoryById(Guid id);
    Task<IEnumerable<Domain.Models.Category>> GetAllCategory();
}