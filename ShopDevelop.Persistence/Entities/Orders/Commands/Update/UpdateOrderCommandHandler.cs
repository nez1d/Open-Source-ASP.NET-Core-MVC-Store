using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Entities.Orders.Commands.Update;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Entities.Orders.Commands.Update;

public class UpdateOrderCommandHandler
    : IRequestHandler<UpdateOrderCommand>
{
    private readonly ILogger logger;
    private readonly IMapper mapper;
    private readonly IOrderRepository orderRepository;

    public UpdateOrderCommandHandler(
        ILogger<UpdateOrderCommandHandler> logger,
        IMapper mapper,
        IOrderRepository orderRepository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.orderRepository = orderRepository;
    }
    
    public async Task Handle(UpdateOrderCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(UpdateOrderCommandHandler)}");

        var order = await orderRepository.GetById(request.Id);

        if (order.ApplicationUserId != request.ApplicationUserId.ToString())
            throw new NotFoundException(typeof(Order), request.Id);
        
        order.Address = request.Address;
        order.Country = request.Country;
        order.City = request.City;
        
        await orderRepository.Update(order, cancellationToken);
        
        logger.LogInformation($"Handled {nameof(UpdateOrderCommandHandler)}");
    }
}