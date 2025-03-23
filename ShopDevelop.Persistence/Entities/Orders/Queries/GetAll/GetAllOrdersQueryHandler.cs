using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Orders.Queries.GetAll;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Orders.Queries.GetAll;

public class GetAllOrdersQueryHandler
    : IRequestHandler<GetAllOrdersQuery, IList<GetAllOrdersVm>>
{
    private readonly ILogger logger;
    private readonly IApplicationDbContext applicationDbContext;

    public GetAllOrdersQueryHandler(
        ILogger<GetAllOrdersQueryHandler> logger,
        IApplicationDbContext applicationDbContext)
    {
        this.logger = logger;
        this.applicationDbContext = applicationDbContext;
    }
    
    public async Task<IList<GetAllOrdersVm>> Handle(GetAllOrdersQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetAllOrdersQueryHandler)}");

        var result = await applicationDbContext.Orders
            .Select(order => 
                new GetAllOrdersVm(
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
                    order.ProductId)
            ).ToListAsync(cancellationToken);
        
        logger.LogInformation($"Handled {nameof(GetAllOrdersQueryHandler)}");

        return result;
    }

}