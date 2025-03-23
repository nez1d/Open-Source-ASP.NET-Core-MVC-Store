using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Orders.Queries.GetById;
using ShopDevelop.Application.Entities.Orders.Queries.GetByProductId;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Persistence.Entities.Orders.Queries.GetAll;

namespace ShopDevelop.Persistence.Entities.Orders.Queries.GetByProductId;

public class GetOrdersByProductIdQueryHandler
    : IRequestHandler<GetOrdersByProductIdQuery, IList<GetOrdersByProductIdVm>>
{
    private readonly ILogger logger;
    private readonly IApplicationDbContext applicationDbContext;

    public GetOrdersByProductIdQueryHandler(
        ILogger<GetOrdersByProductIdQueryHandler> logger,
        IApplicationDbContext applicationDbContext)
    {
        this.logger = logger;
        this.applicationDbContext = applicationDbContext;
    }
    
    public async Task<IList<GetOrdersByProductIdVm>> Handle(GetOrdersByProductIdQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetOrdersByProductIdQueryHandler)}");

        var result = await applicationDbContext.Orders
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
            .ToListAsync(cancellationToken);
        
        
        logger.LogInformation($"Handling {nameof(GetOrdersByProductIdQueryHandler)}");

        return result;
    }
}