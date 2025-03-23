using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Application.Services.Category;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetOrderByIdAsync(Guid orderId);
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
    Task<int> CreateZipCodeAsync();
    Task<decimal> GetOrderTotalPrice(decimal price, uint amount);
}