using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Interfaces.Repository;

namespace ShopDevelop.Application.Repository;

public interface ISellerRepository 
{
    Task<int> CreateAsync(Seller seller, CancellationToken cancellationToken);
    Task UpdateAsync(Seller seller, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Seller>> GetAllAsync();
    Task<Seller> GetByIdAsync(int id);
}