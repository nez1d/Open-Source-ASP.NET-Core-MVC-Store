using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Seller.Queries.GetAll;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Seller.Queries.GetAll;

public class GetAllSellersQueryHandler
    : IRequestHandler<GetAllSellersListQuery, IList<SellerLookupDto>>
{
    public readonly ISellerRepository sellerRepository;
    private readonly ILogger<GetAllSellersQueryHandler> logger;

    public GetAllSellersQueryHandler(
        ISellerRepository sellerRepository,
        ILogger<GetAllSellersQueryHandler> logger)
    {
        this.sellerRepository = sellerRepository;
        this.logger = logger;
    }
    
    public async Task<IList<SellerLookupDto>> Handle(GetAllSellersListQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetAllSellersQueryHandler)}");
        
        var items = await sellerRepository.GetAllAsync();
        
        var result = items
            .Select(seller => 
                new SellerLookupDto(
                    seller.Id,
                    seller.Name,
                    seller.Description,
                    seller.ImagePath,
                    seller.ImageFooterPath)
            )
            .ToList();
        
        logger.LogInformation($"Handling {nameof(GetAllSellersQueryHandler)}");

        return result;
    }
}