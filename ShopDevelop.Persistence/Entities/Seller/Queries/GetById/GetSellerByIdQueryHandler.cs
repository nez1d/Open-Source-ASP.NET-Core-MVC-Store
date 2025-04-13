using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Seller.Queries.GetById;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Seller.Queries.GetById;

public class GetSellerByIdQueryHandler
    : IRequestHandler<GetSellerByIdQuery, GetSellerByIdVm>
{
    private readonly ILogger<GetSellerByIdQueryHandler> logger;
    private readonly ISellerRepository sellerRepository;
    private readonly IMapper mapper;

    public GetSellerByIdQueryHandler(IMapper mapper,
        ILogger<GetSellerByIdQueryHandler> logger,
        ISellerRepository sellerRepository)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.sellerRepository = sellerRepository;
    }
    
    public async Task<GetSellerByIdVm?> Handle(GetSellerByIdQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetSellerByIdQueryHandler)}");
        
        var seller = await sellerRepository.FindByIdAsync(request.Id, cancellationToken);
        
        if (seller == null) return null;
        
        var result = mapper.Map<GetSellerByIdVm>(seller);
        
        logger.LogInformation($"Handled {nameof(GetSellerByIdQueryHandler)}");
        
        return result;
    }
}