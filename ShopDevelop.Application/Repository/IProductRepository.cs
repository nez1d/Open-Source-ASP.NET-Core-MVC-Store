using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Repository;

public interface IProductRepository
{
    Task<Guid> Create(Product product);
    Task<Guid> Update(Product product);
    Task Delete(Guid id);

    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(Guid id);
    IEnumerable<Product> GetByCategory(Guid categoryId);
}