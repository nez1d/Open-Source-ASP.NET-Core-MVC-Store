using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Product.Commands.Create.Shoes;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Product;

namespace ShopDevelop.Persistence.Entities.Product.Command.Create.Shoes;

public class CreateShoesProductCommandHandler : 
    IRequestHandler<CreateShoesProductCommand, Guid>
{
    private readonly IProductRepository productRepository;
    private readonly ProductService productService;
    private readonly ICategoryRepository categoryRepository;
    private readonly ISellerRepository sellerRepository;
    private readonly IMapper mapper;
    private readonly ILogger logger;
    
    public CreateShoesProductCommandHandler(
        ProductService productService,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        ISellerRepository sellerRepository,
        IMapper mapper,
        ILogger<CreateShoesProductCommandHandler> logger)
    {
        this.productRepository = productRepository;
        this.categoryRepository = categoryRepository;
        this.sellerRepository = sellerRepository;
        this.productService = productService;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Guid> Handle(CreateShoesProductCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(CreateShoesProductCommand)}");

        var category = await categoryRepository.GetByNameAsync("Shoes", cancellationToken);
        var seller = await sellerRepository.GetByIdAsync(request.SellerId, cancellationToken);

        if (category == null || seller == null)
            return Guid.Empty;
        
        var discount = await productService.CalculateDiscountByPriceAsync(
                request.Price, request.OldPrice);
        
        var article = await productService.CreateArticulAsync();
        
        var product = mapper.Map<Domain.Entities.Product>(request);
        
        product.CategoryId = category.Id;
        product.CategoryName = category.Name; 
        product.SellerName = seller.Name; 
        product.Discount = discount;
        product.ProductDetail.Article = article; 
        product.ImagePath = "sources/images/products/shoes/" + product.Id + ".jpg";
        product.ImagePath = "sources/images/products/shoes/mini/" + product.Id + ".jpg";
        
        var result = await productRepository.CreateAsync(product, cancellationToken);
    
        logger.LogInformation($"Handled {nameof(CreateShoesProductCommand)}");

        return result;
    }
}