/*using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Orders.Commands.Create;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Orders.Commands.Create;

public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly ILogger logger;
    private readonly IMapper mapper;
    public readonly IOrderRepository orderRepository;

    public CreateOrderCommandHandler(
        ILogger logger,
        IMapper mapper,
        IOrderRepository orderRepository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.orderRepository = orderRepository;
    }
    
    public async Task<Guid> Handle(CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        
        
        return Guid.Empty;
    }
}*/