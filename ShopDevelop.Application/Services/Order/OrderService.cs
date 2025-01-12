using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Domain.Enums;
using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Services.Category;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    public OrderService(IOrderRepository orderRepository) =>
        (this.orderRepository) = (orderRepository);
    
    public async Task<bool> CreateOrderAsync(
        string address, 
        string city, 
        string country, 
        Domain.Models.Product product, 
        ApplicationUser user)
    {
        if (product is not null)
        {
            var order = new Order
            { 
                Address = address,
                City = city,
                Country = country,
                Amount = 1,
                OrderTotal = product.Price,
                CreatedDate = DateTime.UtcNow,
                User = user,
                UserId = Guid.Parse(user.Id),
                Product = product,
                ProductId = product.Id
            };
            await orderRepository.Create(order);
            return true;
        }
        return false;
    }

    public async Task UpdateOrderAsync(Order order)
    {
        await orderRepository.Update(order);
    }

    public async Task DeleteOrderAsync(Guid orderId)
    {
        await orderRepository.Delete(orderId);
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await orderRepository.GetAll();
    }
    public async Task<Order> GetOrderByIdAsync(Guid orderId)
    {
        return await orderRepository.GetById(orderId);
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId)
    {
        return await orderRepository.GetByUserId(userId);
    }

    public async Task<string> CreateZipCodeAsync()
    {
        Random random = new Random();
        return random.Next(1000, 9999).ToString();
    }
}