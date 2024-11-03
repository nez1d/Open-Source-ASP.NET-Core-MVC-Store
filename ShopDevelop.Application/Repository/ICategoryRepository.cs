namespace ShopDevelop.Application.Repository;

public interface ICategoryRepository
{
    Task<Guid> CreateCategory(Domain.Models.Category category,
        CancellationToken cancellationToken);
    Task EditCategory(Guid id);
    Task DeleteCategory(Guid id);
    Task<Domain.Models.Category> GetCategoryById(Guid id);
    Task<IEnumerable<Domain.Models.Category>> GetAllCategory();
}
