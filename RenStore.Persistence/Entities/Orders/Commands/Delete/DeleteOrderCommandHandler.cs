using MediatR;
using Microsoft.Extensions.Logging;
using RenStore.Application.Entities.Orders.Commands.Delete;
using RenStore.Application.Repository;

namespace RenStore.Persistence.Entities.Orders.Commands.Delete;

public class DeleteOrderCommandHandler 
    : IRequestHandler<DeleteOrderCommand>
{
    private readonly ILogger logger;
    private readonly IOrderRepository orderRepository;

    public DeleteOrderCommandHandler(
        ILogger<DeleteOrderCommandHandler> logger,
        IOrderRepository orderRepository)
    {
        this.logger = logger;
        this.orderRepository = orderRepository;
    }
    
    public async Task Handle(DeleteOrderCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(DeleteOrderCommandHandler)}");
        
        await orderRepository.DeleteAsync(request.OrderId, cancellationToken);
        
        logger.LogInformation($"Handled {nameof(DeleteOrderCommandHandler)}");
    }
}