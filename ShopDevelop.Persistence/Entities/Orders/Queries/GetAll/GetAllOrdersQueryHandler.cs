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
    private readonly IOrderRepository orderRepository;

    public GetAllOrdersQueryHandler(
        ILogger<GetAllOrdersQueryHandler> logger,
        IOrderRepository orderRepository)
    {
        this.logger = logger;
        this.orderRepository = orderRepository;
    }
    
    public async Task<IList<GetAllOrdersVm>> Handle(GetAllOrdersQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetAllOrdersQueryHandler)}");

        var items = await orderRepository.GetAllAsync(cancellationToken); 

        var result = 
            items.Select(order => 
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
            )
            .ToList();
        
        logger.LogInformation($"Handled {nameof(GetAllOrdersQueryHandler)}");

        return result;
    }

}