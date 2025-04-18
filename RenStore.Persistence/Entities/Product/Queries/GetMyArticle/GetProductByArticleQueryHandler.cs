using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RenStore.Application.Entities.Product.Queries.GetByArticle;
using RenStore.Application.Repository;
using RenStore.Persistence.Entities.Product.Queries.GetProduct;

namespace RenStore.Persistence.Entities.Product.Queries.GetMyArticle;

public class GetProductByArticleQueryHandler 
    : IRequestHandler<GetProductByArticleQuery, GetProductByArticleVm>
{
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;
    private readonly ILogger<GetProductByIdQueryHandler> logger;
    
    public GetProductByArticleQueryHandler(
        IMapper mapper,
        IProductRepository productRepository,
        ILogger<GetProductByIdQueryHandler> logger)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
        this.logger = logger;
    }
    
    public async Task<GetProductByArticleVm> Handle(GetProductByArticleQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetProductByArticleQueryHandler)}");

        var detail = await productRepository.FindDetailByArticleIdAsync(request.Article, cancellationToken);

        if (detail is null) 
            return null;

        var product = await productRepository.GetByIdAsync(detail.ProductId, cancellationToken);
        
        var result = mapper.Map<GetProductByArticleVm>(product);
        
        result.ProductDetail = detail;
        result.ProductDetailId = detail.Id;
        result.ProductId = detail.ProductId;

        if (product.CategoryName == "Clothes" &&
            product.ClothesProductId != Guid.Empty)
        {
            result.ClothesProduct = await productRepository.GetClothesByIdAsync(
                product.ClothesProductId, cancellationToken);
        }
        else if (product.CategoryName == "Shoes" &&
                 product.ShoesProductId != Guid.Empty)
        {
            result.ShoesProduct = await productRepository.GetShoesByIdAsync(
                product.ShoesProductId, cancellationToken);
        }
        
        logger.LogInformation($"Handled {nameof(GetProductByArticleQueryHandler)}");
        
        return result;
    }
}