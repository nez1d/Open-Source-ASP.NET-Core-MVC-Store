using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Interfaces.Repository;

namespace ShopDevelop.Application.Repository;

public interface ISellerRepository 
{
    Task<Guid> Create(Seller seller);
    Task Update(Seller seller);
    Task Delete(Guid id);
    Task<IEnumerable<Seller>> GetAll();
    Task<Seller> GetById(uint id);
}