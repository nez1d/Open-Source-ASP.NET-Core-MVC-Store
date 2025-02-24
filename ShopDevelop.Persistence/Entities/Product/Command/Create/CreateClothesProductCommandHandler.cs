using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Product.Commands.Create;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Application.Services.Seller;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Entities.Products;

namespace ShopDevelop.Persistence.Entities.Product.Command.Create;

public class CreateClothesProductCommandHandler 
    : IRequestHandler<CreateClothesProductCommand, Guid>
{
    private readonly IProductRepository productRepository;
    private readonly IProductService productService;
    private readonly ICategoryService categoryService;
    private readonly ISellerService sellerService;
    private readonly IMapper mapper;
    private readonly ILogger logger;
    
    public CreateClothesProductCommandHandler(
        IProductService productService,
        IProductRepository productRepository,
        ICategoryService categoryService,
        ISellerService sellerService,
        IMapper mapper,
        ILogger<CreateClothesProductCommandHandler> logger)
    {
        this.productRepository = productRepository;
        this.categoryService = categoryService;
        this.sellerService = sellerService;
        this.productService = productService;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Guid> Handle(CreateClothesProductCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(CreateClothesProductCommand)} ");

        var category = await categoryService.GetByName(request.CategoryName);
        var seller = await sellerService.GetSellerByIdAsync(request.SellerId);
        
        if(category == null || seller == null)
            return Guid.Empty;
        
        var discount = await productService.CalculateDiscountByPriceAsync(request.Price, request.OldPrice);
        var article = await productService.CreateArticulAsync();
        
        var product = mapper.Map<Domain.Entities.Product>(request);

        /*var product = new Domain.Entities.Product()
        {
            Category = category,
            Seller = seller,
            Discount = discount,
            ClothesProduct = new ClothesProduct()
            {
                
            },
            ProductDetail = new ProductDetail()
            {
                Article = article,
            }
        };*/
        
        product.Category = category;
        product.Seller = seller;
        product.Discount = discount;
        product.ProductDetail.Article = article;
        
        var result = await productRepository.Create(product, cancellationToken);
    
        logger.LogInformation($"Handled {nameof(CreateClothesProductCommand)} ");

        return result;
    }
}