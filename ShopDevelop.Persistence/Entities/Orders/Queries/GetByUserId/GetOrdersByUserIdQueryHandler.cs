using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Orders.Queries.GetByUserId;
using ShopDevelop.Application.Interfaces;

namespace ShopDevelop.Persistence.Entities.Orders.Queries.GetByUserId;

public class GetOrdersByUserIdQueryHandler
    : IRequestHandler<GetOrdersByUserIdQuery, IList<GetOrdersByUserIdVm>>
{
    private readonly ILogger logger;
    private readonly ApplicationDbContext applicationDbContext;

    public GetOrdersByUserIdQueryHandler(
        ILogger<GetOrdersByUserIdQueryHandler> logger,
        ApplicationDbContext applicationDbContext)
    {
        this.logger = logger;
        this.applicationDbContext = applicationDbContext;
    }
    
    public async Task<IList<GetOrdersByUserIdVm>> Handle(GetOrdersByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetOrdersByUserIdQueryHandler)}");

        var result = await applicationDbContext.Orders
            .Select(order => 
                new GetOrdersByUserIdVm(
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
            .ToListAsync(cancellationToken);
        
        logger.LogInformation($"Handling {nameof(GetOrdersByUserIdQueryHandler)}");

        return result;
    }
}