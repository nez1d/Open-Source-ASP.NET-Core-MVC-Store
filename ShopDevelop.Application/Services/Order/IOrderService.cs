using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Application.Services.Category;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken);
    Task<Order> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId, CancellationToken cancellationToken);
    Task<int> CreateZipCodeAsync();
    Task<decimal> GetOrderTotalPrice(decimal price, uint amount);
}