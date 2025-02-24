using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Interfaces.Repository;

namespace ShopDevelop.Application.Repository;

public interface IProductRepository 
{
    Task<Guid> Create(Product product, CancellationToken cancellationToken);
    Task Update(Product product);
    Task Delete(Guid id);
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(Guid? id);
    IEnumerable<Product> GetByCategoryId(Guid categoryId);
}