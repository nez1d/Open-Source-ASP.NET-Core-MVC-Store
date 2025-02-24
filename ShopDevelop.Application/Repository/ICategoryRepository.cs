using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Interfaces.Repository;

namespace ShopDevelop.Application.Repository;

public interface ICategoryRepository 
{
    Task<Guid> Create(Category category);
    Task Update(Category category);
    Task Delete(Guid id);
    Task<Category> GetById(Guid id);
    Task<Category> GetByName(string name);
    Task<IEnumerable<Category>> GetAll();
    Task<object> GetById(int categoryId);
}
