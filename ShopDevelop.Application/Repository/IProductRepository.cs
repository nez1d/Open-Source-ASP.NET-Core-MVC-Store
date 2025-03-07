using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Interfaces.Repository;

namespace ShopDevelop.Application.Repository;

public interface IProductRepository 
{
    Task<Guid> CreateAsync(Product product, CancellationToken cancellationToken);
    Task UpdateAsync(Product product, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<ProductDetail?> GetDetailsByProductIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Product?>> GetByCategoryIdAsync(Guid categoryId);
}