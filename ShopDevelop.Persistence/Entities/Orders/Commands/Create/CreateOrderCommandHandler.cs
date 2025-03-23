using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Orders.Commands.Create;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Enums;

namespace ShopDevelop.Persistence.Entities.Orders.Commands.Create;

public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly ILogger logger;
    private readonly IMapper mapper;
    private readonly IOrderRepository orderRepository;
    private readonly IOrderService orderService; 
    private readonly IProductRepository productRepository;

    public CreateOrderCommandHandler(
        ILogger<CreateOrderCommandHandler> logger,
        IMapper mapper,
        IOrderRepository orderRepository,
        IOrderService orderService,
        IProductRepository productRepository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.orderRepository = orderRepository;
        this.orderService = orderService;
        this.productRepository = productRepository;
    }
    
    public async Task<Guid> Handle(CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(CreateOrderCommandHandler)}");
        
        var order = mapper.Map<Order>(request);
        
        var product = await productRepository.GetByIdAsync(order.ProductId, cancellationToken);
        
        order.Status = DeliveryStatus.AwaitingConfirmation;
        order.ZipCode = await orderService.CreateZipCodeAsync();
        order.OrderTotal = await orderService.GetOrderTotalPrice(product.Price, request.Amount);
        order.CreatedDate = DateTime.UtcNow;
        
        var result = await orderRepository.Create(order, cancellationToken);
        
        logger.LogInformation($"Handled {nameof(CreateOrderCommandHandler)}");
        
        return result;
    }
}