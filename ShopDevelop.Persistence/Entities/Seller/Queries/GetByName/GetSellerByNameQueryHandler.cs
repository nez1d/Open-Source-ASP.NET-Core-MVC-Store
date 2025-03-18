using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Seller.Queries.GetByName;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Seller.Queries.GetByName;

public class GetSellerByNameQueryHandler 
    : IRequestHandler<GetSellerByNameQuery, GetSellerByNameVm>
{
    private readonly ILogger<GetSellerByNameQueryHandler> logger;
    private readonly ISellerRepository sellerRepository;
    private readonly IMapper mapper;

    public GetSellerByNameQueryHandler(IMapper mapper,
        ILogger<GetSellerByNameQueryHandler> logger,
        ISellerRepository sellerRepository)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.sellerRepository = sellerRepository;
    }
    
    public async Task<GetSellerByNameVm> Handle(GetSellerByNameQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetSellerByNameQueryHandler)}");
        
        var seller = await sellerRepository.GetByNameAsync(request.Name, cancellationToken);
        
        var result = mapper.Map<GetSellerByNameVm>(seller);
        
        logger.LogInformation($"Handled {nameof(GetSellerByNameQueryHandler)}");
        
        return result;
    }
}