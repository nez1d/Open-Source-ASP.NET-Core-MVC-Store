using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Repository;

public interface IOrderRepository
{
    /// <summary>
    /// Create new Order.
    /// </summary>
    /// <param name="order">Order Entity.</param>
    /// <returns>Return Order Id.</returns>
    Task<Guid> Create(Order order);
    /// <summary>
    /// Update Order.
    /// </summary>
    /// <param name="order">Order Entity.</param>
    /// <returns></returns>
    Task Update(Order order);
    /// <summary>
    /// Delete Order.
    /// </summary>
    /// <param name="id">Order Id.</param>
    /// <returns></returns>
    Task Delete(Guid id);
    /// <summary>
    /// Get all Orders.
    /// </summary>
    /// <returns>Return List Orders.</returns>
    Task<IEnumerable<Order>> GetAll();
    /// <summary>
    /// Get Order by orderId.
    /// </summary>
    /// <param name="id">Order Id.</param>
    /// <returns>Return Order.</returns>
    Task<Order> GetById(Guid id);
    /// <summary>
    /// Get List Orders By User Id.
    /// </summary>
    /// <param name="userId">User Id.</param>
    /// <returns>Return List Orders.</returns>
    Task<IEnumerable<Order>> GetByUserId(Guid userId);
}