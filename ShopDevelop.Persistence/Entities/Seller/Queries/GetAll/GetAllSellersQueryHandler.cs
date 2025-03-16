using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Seller.Queries.GetAll;
using ShopDevelop.Application.Interfaces;

namespace ShopDevelop.Persistence.Entities.Seller.Queries.GetAll;

public class GetAllSellersQueryHandler
    : IRequestHandler<GetAllSellersListQuery, IList<SellerLookupDto>>
{
    public readonly IApplicationDbContext applicationDbContext;
    private readonly ILogger<GetAllSellersQueryHandler> logger;

    public GetAllSellersQueryHandler(
        IApplicationDbContext applicationDbContext,
        ILogger<GetAllSellersQueryHandler> logger)
    {
        this.applicationDbContext = applicationDbContext;
        this.logger = logger;
    }
    
    public async Task<IList<SellerLookupDto>> Handle(GetAllSellersListQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetAllSellersQueryHandler)}");
        
        var result = await applicationDbContext.Sellers
            .Select(seller => 
                new SellerLookupDto(
                    seller.Id,
                    seller.Name,
                    seller.Description,
                    seller.ImagePath,
                    seller.ImageFooterPath)
            )
            .ToListAsync(cancellationToken);
        
        logger.LogInformation($"Handling {nameof(GetAllSellersQueryHandler)}");

        return result;
    }
}