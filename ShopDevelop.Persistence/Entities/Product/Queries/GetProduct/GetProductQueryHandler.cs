using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Entities.Product.Queries.GetProduct;
using ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Entities.Products;

namespace ShopDevelop.Persistence.Entities.Product.Queries.GetProduct;

public class GetProductQueryHandler 
    : IRequestHandler<GetProductQuery, ProductVm>
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;
    private readonly ILogger<GetProductQueryHandler> logger;
    
    public GetProductQueryHandler(
        IProductRepository productRepository,
        IMapper mapper,
        ILogger<GetProductQueryHandler> logger)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
        this.logger = logger;
    }
    
    public async Task<ProductVm> Handle(GetProductQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetProductQuery)}");

        var product = await productRepository
            .GetByIdAsync(request.Id, cancellationToken);
            
        if (product.Id != request.Id)
            throw new NotFoundException(typeof(Domain.Entities.Product), request.Id);
        
        var result = mapper.Map<ProductVm>(product);

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
        
        logger.LogInformation($"Handled {nameof(GetProductQuery)}");
        return result;
    }
}