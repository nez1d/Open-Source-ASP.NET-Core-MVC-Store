using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RenStore.Application.Repository;
using RenStore.Application.Services.Cart;
using RenStore.Application.Services.Product;
using RenStore.Domain.Entities;
using RenStore.Domain.Enums;

namespace RenStore.Application.Services.Category;

public class OrderService 
{
    private readonly IOrderRepository orderRepository;
    public OrderService(IOrderRepository orderRepository) =>
            (this.orderRepository) = (orderRepository);

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