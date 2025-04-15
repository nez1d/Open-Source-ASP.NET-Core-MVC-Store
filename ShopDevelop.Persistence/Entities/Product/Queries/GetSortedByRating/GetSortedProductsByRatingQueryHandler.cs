using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Product.Queries.GetSortedByPrice;
using ShopDevelop.Application.Entities.Product.Queries.GetSortedByRating;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Product.Queries.GetSortedByRating;

public class GetSortedProductsByRatingQueryHandler 
    : IRequestHandler<GetSortedProductsByRatingQuery, IList<GetSortedProductsByRatingVm>>
{
    private readonly ILogger<GetSortedProductsByRatingQueryHandler> logger;
    private readonly IProductRepository productRepository;

    public GetSortedProductsByRatingQueryHandler(
        ILogger<GetSortedProductsByRatingQueryHandler> logger, 
        IProductRepository productRepository)
    {
        this.logger = logger;
        this.productRepository = productRepository;
    }
    
    public async Task<IList<GetSortedProductsByRatingVm>> Handle(GetSortedProductsByRatingQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetSortedProductsByRatingQueryHandler)}");
        
        var items = await productRepository.FindSortedByRatingAsync(
            cancellationToken: cancellationToken, 
            descending: request.Descending);

        var result = items.Select(product =>
                new GetSortedProductsByRatingVm(
                    product.Id,
                    product.ProductName, 
                    product.Price,
                    product.Rating,
                    product.ImageMiniPath,
                    product.SellerName))
            .ToList();
        
        logger.LogInformation($"Handled {nameof(GetSortedProductsByRatingQueryHandler)}");
        
        return result;
    }
}