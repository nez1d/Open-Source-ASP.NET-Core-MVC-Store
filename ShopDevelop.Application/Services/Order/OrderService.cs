using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Domain.Enums;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Services.Category;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly IProductService productService;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IHttpContextAccessor httpContextAccessor;
    public OrderService(IOrderRepository orderRepository,
        UserManager<ApplicationUser> userManager,
        IProductService productService,
        IHttpContextAccessor httpContextAccessor)
    {
        this.orderRepository = orderRepository;
        this.userManager = userManager;
        this.productService = productService;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<ApplicationUser> GetUserBySession()
    {
        string userId = httpContextAccessor.HttpContext.
            User.FindFirst("UserId").ToString();
        
        return userManager.Users.SingleOrDefault(x => 
            x.Id == Guid.Parse(userId));
    }
    
    public async Task CreateOrderAsync(string address, string city, string country, Guid productId)
    {
        var user = await GetUserBySession();
        var product = await productService.GetByIdAsync(productId);
        var order = new Order
        { 
            Address = address,
            City = city,
            Country = country,
            Amount = 1,
            ZipCode = await CreateZipCodeAsync(),
            Status = DeliveryStatus.AwaitingConfirmation,
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