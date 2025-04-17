using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Entities.Product.Queries.GetById;
using ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Entities.Products;

namespace ShopDevelop.Persistence.Entities.Product.Queries.GetProduct;

public class GetProductByIdQueryHandler 
    : IRequestHandler<GetProductByIdQuery, GetProductByIdVm>
{
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;
    private readonly ILogger<GetProductByIdQueryHandler> logger;
    
    public GetProductByIdQueryHandler(
        IMapper mapper,
        IProductRepository productRepository,
        ILogger<GetProductByIdQueryHandler> logger)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
        this.logger = logger;
    }
    
    public async Task<GetProductByIdVm> Handle(GetProductByIdQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetProductByIdQuery)}");

        var product = await productRepository
            .FindByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return null;
        
        var result = mapper.Map<GetProductByIdVm>(product);

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
        
        result.ProductDetail = await productRepository.FindDetailsByProductIdAsync(
            result.ProductId, cancellationToken);
        
        logger.LogInformation($"Handled {nameof(GetProductByIdQuery)}");
        return result;
    }
}