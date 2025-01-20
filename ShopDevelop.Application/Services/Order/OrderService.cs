using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Cart;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Domain.Enums;
using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Services.Category;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly ShoppingCartService shoppingCartService;
    public OrderService(IOrderRepository orderRepository,
        ShoppingCartService shoppingCartService) =>
            (this.orderRepository, this.shoppingCartService) = 
            (orderRepository, shoppingCartService);
    
    public async Task<bool> CreateOrderAsync(
        string address, 
        string city, 
        string country, 
        Domain.Models.Product product, 
        ApplicationUser user)
    {
        if (product is not null)
        {
            var code = await CreateZipCodeAsync();
            
            var order = new Order
            { 
                Address = address,
                City = city,
                Country = country,
                Amount = 1,
                ZipCode = code,
                Status = DeliveryStatus.AwaitingConfirmation,
                OrderTotal = product.Price,
                CreatedDate = DateTime.UtcNow,
                ApplicationUserId = user.Id,
                ProductId = product.Id
            };
            
            var result = await orderRepository.Create(order);
            
            if(result != Guid.Empty)
            {
                var data = await shoppingCartService.RemoveFromCart(product);
                return data;
            }
        }
        return false;
    }

    public async Task UpdateOrderAsync(
        Guid orderId,
        string address, 
        string city, 
        string country)
    {
        var data = await orderRepository.GetById(orderId);
        
        data.Address = address;
        data.City = city;
        data.Country = country;
        
        await orderRepository.Update(data);
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

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
    {
        return await orderRepository.GetByUserId(userId);
    }

    public async Task<int> CreateZipCodeAsync()
    {
        Random random = new Random();
        return random.Next(1000, 9999);
    }
}