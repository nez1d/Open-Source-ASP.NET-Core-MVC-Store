using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RenStore.Application.Entities.Product.Queries.GetBySellerId;
using RenStore.Application.Repository;
using RenStore.Persistence.Entities.Product.Queries.GetProduct;

namespace RenStore.Persistence.Entities.Product.Queries.GetBySellerId;

public class GetProductBySellerIdQueryHandler 
    : IRequestHandler<GetProductBySellerIdQuery, IList<GetProductBySellerIdVm>>
{
    private readonly IProductRepository productRepository;
    private readonly ILogger<GetProductByIdQueryHandler> logger;
    
    public GetProductBySellerIdQueryHandler(
        IProductRepository productRepository,
        ILogger<GetProductByIdQueryHandler> logger)
    {
        this.productRepository = productRepository;
        this.logger = logger;
    }
    
    public async Task<IList<GetProductBySellerIdVm>> Handle(GetProductBySellerIdQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetProductBySellerIdQueryHandler)}");

        var products = await productRepository
            .FindBySellerIdAsync(request.SellerId, cancellationToken);
        
        var result = products
            .Select(product => 
                new GetProductBySellerIdVm(
                    product.Id,
                    product.ProductName,
                    product.Price,
                    product.Rating,
                    product.ImageMiniPath,
                    product.SellerName)
            )
            .ToList();
        
        logger.LogInformation($"Handled {nameof(GetProductBySellerIdQueryHandler)}");
        
        return result;
    }
}