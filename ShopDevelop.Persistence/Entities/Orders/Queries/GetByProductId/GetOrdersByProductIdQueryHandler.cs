using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Orders.Queries.GetById;
using ShopDevelop.Application.Entities.Orders.Queries.GetByProductId;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;
using ShopDevelop.Persistence.Entities.Orders.Queries.GetAll;

namespace ShopDevelop.Persistence.Entities.Orders.Queries.GetByProductId;

public class GetOrdersByProductIdQueryHandler
    : IRequestHandler<GetOrdersByProductIdQuery, IList<GetOrdersByProductIdVm>>
{
    private readonly ILogger logger;
    private readonly IOrderRepository orderRepository;

    public GetOrdersByProductIdQueryHandler(
        ILogger<GetOrdersByProductIdQueryHandler> logger,
        IOrderRepository orderRepository)
    {
        this.logger = logger;
        this.orderRepository = orderRepository;
    }
    
    public async Task<IList<GetOrdersByProductIdVm>> Handle(GetOrdersByProductIdQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetOrdersByProductIdQueryHandler)}");
        
        var items = await orderRepository.GetByProductIdAsync(request.ProductId, cancellationToken); 

        var result = items
            .Select(order => 
                new GetOrdersByProductIdVm(
                    order.Id,
                    order.Address,
                    order.City,
                    order.Country,
                    order.Amount,
                    order.ZipCode,
                    order.Status,
                    order.OrderTotal,
                    order.CreatedDate,
                    order.ApplicationUserId,
                    order.ProductId
            ))
            .ToList();
        
        
        logger.LogInformation($"Handled {nameof(GetOrdersByProductIdQueryHandler)}");

        return result;
    }
}