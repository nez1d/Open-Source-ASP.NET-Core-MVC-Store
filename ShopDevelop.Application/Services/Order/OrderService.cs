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
    private readonly IProductService productService;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly UserManager<ApplicationUser> userManager;
    private IOrderService orderServiceImplementation;
    public OrderService(IOrderRepository orderRepository,
        IProductService productService,
        IHttpContextAccessor httpContextAccessor)
    {
        this.orderRepository = orderRepository;
        this.productService = productService;
        this.httpContextAccessor = httpContextAccessor;
    }
    
    public async Task CreateOrderAsync(string address, string city, string country, Guid productId, ApplicationUser user)
    {
        var product = await productService.GetByIdAsync(productId);
        var order = new Order
        { 
            Address = address,
            City = city,
            Country = country,
            Amount = 1,
            /*ZipCode = await CreateZipCodeAsync(),
            Status = DeliveryStatus.AwaitingConfirmation,*/
            OrderTotal = 1,
            CreatedDate = DateTime.UtcNow,
            User = user,
            UserId = user.Id,
            Product = product,
            ProductId = productId
        };
        await orderRepository.Create(order);
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