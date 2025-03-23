using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Orders.Queries.GetById;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Entities.Orders.Queries.GetById;

public class GetOrderByIdQueryHandler
 : IRequestHandler<GetOrderByIdQuery, GetOrderByIdVm>
{
    private readonly ILogger logger;
    private readonly IMapper mapper;
    private readonly IOrderRepository orderRepository;

    public GetOrderByIdQueryHandler(
        ILogger<GetOrderByIdQueryHandler> logger,
        IMapper mapper,
        IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
        this.mapper = mapper;
        this.logger = logger;
    }
    
    public async Task<GetOrderByIdVm> Handle(GetOrderByIdQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetOrderByIdQueryHandler)}");
        
        var order = await orderRepository.GetById(request.Id);
        
        var result = mapper.Map<GetOrderByIdVm>(order);
        
        logger.LogInformation($"Handling {nameof(GetOrderByIdQueryHandler)}");

        return result;
    } 
}