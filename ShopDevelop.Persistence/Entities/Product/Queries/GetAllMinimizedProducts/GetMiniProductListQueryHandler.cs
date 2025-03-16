using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Application.Interfaces;

namespace ShopDevelop.Persistence.Entities.Product.Queries.GetMinimizedProducts;

public class GetMiniProductListQueryHandler
    : IRequestHandler<GetMiniProductListQuery, List<ProductMiniLookupDto>>
{
    public readonly IApplicationDbContext applicationDbContext;
    private readonly ILogger<GetMiniProductListQueryHandler> logger;

    public GetMiniProductListQueryHandler(IApplicationDbContext applicationDbContext,
        ILogger<GetMiniProductListQueryHandler> logger)
    {
        this.applicationDbContext = applicationDbContext;
        this.logger = logger;
    }
    
    
    public async Task<List<ProductMiniLookupDto>> Handle(
        GetMiniProductListQuery query,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetMiniProductListQueryHandler)}");
        
        var result = await applicationDbContext.Products
            .Select(product => 
                new ProductMiniLookupDto(
                    product.Id,
                    product.ProductName,
                    product.Price,
                    product.Rating,
                    product.ImageMiniPath,
                    product.Seller.Name)
                ).ToListAsync(cancellationToken);
        
        logger.LogInformation($"Handled {nameof(GetMiniProductListQueryHandler)}");
        
        return result;
    }
}