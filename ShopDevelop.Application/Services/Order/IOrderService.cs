using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Services.Category;

public interface IOrderService
{
    /// <summary>
    /// Create new Order.
    /// </summary>
    /// <param name="address">Delivery address.</param>
    /// <param name="city">Delivery city.</param>
    /// <param name="country">Delivery country.</param>
    /// <param name="productId">Product Id.</param>
    /// <param name="user">Application User Model.</param>
    /// <returns></returns>
    Task CreateOrderAsync(string address, string city, string country, Guid productId, ApplicationUser user);
    /// <summary>
    /// Update Order.
    /// </summary>
    /// <param name="order">Order Entity.</param>
    /// <returns></returns>
    Task UpdateOrderAsync(Order order);
    /// <summary>
    /// Delete Order.
    /// </summary>
    /// <param name="orderId">Order Id.</param>
    /// <returns></returns>
    Task DeleteOrderAsync(Guid orderId);
    /// <summary>
    /// Get all Orders.
    /// </summary>
    /// <returns>Return List Orders.</returns>
    Task<IEnumerable<Order>> GetAllAsync();
    /// <summary>
    /// Get Order By Order Id.
    /// </summary>
    /// <param name="orderId">Order Id.</param>
    /// <returns>Return Order.</returns>
    Task<Order> GetOrderByIdAsync(Guid orderId);
    /// <summary>
    /// Get Orders by User Id.
    /// </summary>
    /// <param name="userId">User Id.</param>
    /// <returns>Return List Orders.</returns>
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId);
}