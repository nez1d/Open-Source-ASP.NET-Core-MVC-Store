using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Application.Repository;

public interface ICategoryRepository 
{
    Task<int> CreateAsync(Category category, CancellationToken cancellationToken);
    Task UpdateAsync(Category category, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task<Category> GetByNameAsync(string name);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
}
