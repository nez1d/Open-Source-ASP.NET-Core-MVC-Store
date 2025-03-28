using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Cart;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Enums;

namespace ShopDevelop.Application.Services.Category;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    public OrderService(IOrderRepository orderRepository) =>
            (this.orderRepository) = (orderRepository);
    
    

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await orderRepository.GetAll();
    }
    public async Task<Order> GetOrderByIdAsync(Guid orderId)
    {
        return await orderRepository.GetById(orderId);
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
    {
        return await orderRepository.GetByUserId(userId);
    }

    public async Task<int> CreateZipCodeAsync()
    {
        Random random = new Random();
        return random.Next(1000, 9999);
    }

    public async Task<DeliveryStatus> ChangeOrderDeliveryStatus()
    {
        return DeliveryStatus.AwaitingConfirmation;
    }

    public async Task<decimal> GetOrderTotalPrice(decimal price, uint amount)
    {
        return price * amount;
    }
}