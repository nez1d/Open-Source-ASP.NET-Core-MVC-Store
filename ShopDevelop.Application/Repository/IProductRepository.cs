using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Interfaces.Repository;

namespace ShopDevelop.Application.Repository;

public interface IProductRepository 
{
    Task<Guid> Create(Product product, CancellationToken cancellationToken);
    Task Update(Product product, CancellationToken cancellationToken);
    Task Delete(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(Guid id, CancellationToken cancellationToken);
    Task<ProductDetail?> GetDetailsByProductId(Guid id, CancellationToken cancellationToken);
    IEnumerable<Product> GetByCategoryId(Guid categoryId);
}