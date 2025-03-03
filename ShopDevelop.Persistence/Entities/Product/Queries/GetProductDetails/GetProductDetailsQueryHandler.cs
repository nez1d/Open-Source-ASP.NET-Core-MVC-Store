using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Product.Queries.GetProductDetails;

public class GetProductDetailsQueryHandler 
    : IRequestHandler<GetProductDetailsQuery, ProductDetailVm>
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;
    private readonly ILogger logger;
    
    public GetProductDetailsQueryHandler(
        IProductRepository productRepository,
        IMapper mapper,
        ILogger<GetProductDetailsQuery> logger)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
        this.logger = logger;
    }
    
    public async Task<ProductDetailVm> Handle(GetProductDetailsQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetProductDetailsQuery)}");

        var model = productRepository.GetDetailsByProductId(request.Id, cancellationToken);
        
        var result = mapper.Map<ProductDetailVm>(model);
        
        logger.LogInformation($"Handled {nameof(GetProductDetailsQuery)}");
        
        return result;
    }
}