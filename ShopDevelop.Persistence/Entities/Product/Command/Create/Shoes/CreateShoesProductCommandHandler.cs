using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Product.Commands.Create.Clothes;
using ShopDevelop.Application.Entities.Product.Commands.Create.Shoes;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Application.Services.Seller;

namespace ShopDevelop.Persistence.Entities.Product.Command.Create.Shoes;

public class CreateShoesProductCommandHandler : 
    IRequestHandler<CreateShoesProductCommand, Guid>
{
    private readonly IProductRepository productRepository;
    private readonly IProductService productService;
    private readonly ICategoryService categoryService;
    private readonly ISellerService sellerService;
    private readonly IMapper mapper;
    private readonly ILogger logger;
    
    public CreateShoesProductCommandHandler(
        IProductService productService,
        IProductRepository productRepository,
        ICategoryService categoryService,
        ISellerService sellerService,
        IMapper mapper,
        ILogger<CreateShoesProductCommandHandler> logger)
    {
        this.productRepository = productRepository;
        this.categoryService = categoryService;
        this.sellerService = sellerService;
        this.productService = productService;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Guid> Handle(CreateShoesProductCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(CreateShoesProductCommand)}");

        var category = await categoryService.GetByName("Shoes");
        var seller = await sellerService.GetSellerByIdAsync(request.SellerId);

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
        
        var result = await productRepository.CreateAsync(product, cancellationToken);
    
        logger.LogInformation($"Handled {nameof(CreateShoesProductCommand)}");

        return result;
    }
}