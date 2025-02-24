

using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Interfaces.Repository;

namespace ShopDevelop.Application.Repository;

public interface IOrderRepository
{
    Task<Guid> Create(Order order);
    Task Update(Order order);
    Task Delete(Guid id);
    Task<IEnumerable<Order>> GetAll();
    Task<Order> GetById(Guid id);
    Task<IEnumerable<Order>> GetByUserId(string userId);
}