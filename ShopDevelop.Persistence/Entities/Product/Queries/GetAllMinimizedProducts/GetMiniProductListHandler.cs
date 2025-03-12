using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Application.Interfaces;

namespace ShopDevelop.Persistence.Entities.Product.Queries.GetMinimizedProducts;

public class GetMiniProductListHandler
    : IRequestHandler<GetMiniProductListQuery, List<ProductMiniLookupDto>>
{
    public readonly IApplicationDbContext applicationDbContext;
    private readonly ILogger<GetMiniProductListHandler> logger;

    public GetMiniProductListHandler(IApplicationDbContext applicationDbContext,
        ILogger<GetMiniProductListHandler> logger)
    {
        this.applicationDbContext = applicationDbContext;
        this.logger = logger;
    }
    
    
    public async Task<List<ProductMiniLookupDto>> Handle(
        GetMiniProductListQuery query,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetMiniProductListHandler)}");
        
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
        
        logger.LogInformation($"Handled {nameof(GetMiniProductListHandler)}");
        
        return result;
    }
}