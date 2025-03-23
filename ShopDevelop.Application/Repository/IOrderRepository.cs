

using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Interfaces.Repository;

namespace ShopDevelop.Application.Repository;

public interface IOrderRepository
{
    Task<Guid> Create(Order order, CancellationToken cancellationToken);
    Task Update(Order order, CancellationToken cancellationToken);
    Task Delete(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetAll();
    Task<Order> GetById(Guid id);
    Task<IEnumerable<Order>> GetByUserId(string userId);
}