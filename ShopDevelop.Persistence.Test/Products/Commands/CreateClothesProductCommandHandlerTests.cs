/*using AutoMapper;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Product.Commands.Create;
using ShopDevelop.Application.Entities.Product.Commands.Create.Clothes;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Application.Services.Seller;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Entities.Products;
using ShopDevelop.Domain.Enums;
using ShopDevelop.Domain.Enums.Clothes;
using ShopDevelop.Persistence.Test.Common;
using ShopDevelop.Persistence.Entities.Product.Command.Create;
using ShopDevelop.Persistence.Entities.Product.Command.Create.Clothes;
using ShopDevelop.Persistence.Repository;

namespace ShopDevelop.Persistence.Test.Products.Commands;

public class CreateClothesProductCommandHandlerTests : TestCommandBase
{
    private IProductRepository productRepository;
    private readonly IProductService productService;
    private ICategoryRepository categoryRepository;
    private ICategoryService categoryService;
    private ISellerService sellerService;
    private readonly IMapper mapper;
    private readonly ILogger<CreateClothesProductCommandHandler> logger;
    
    [Fact]
    public async Task CreateProductCommandHandler_Success_Tests()
    {
        // Arrange
        productRepository = new ProductRepository(context);
        categoryRepository = new CategoryRepository(context);
        categoryService = new CategoryService(categoryRepository);
        var sellerRepository = new SellerRepository(context);
        sellerService = new SellerService(sellerRepository);
        
        var handler = new CreateClothesProductCommandHandler(
            productService: productService, 
            productRepository: productRepository, 
            categoryService: categoryService, 
            sellerService: sellerService, 
            mapper: mapper, 
            logger: logger);
        // Act
        var productId = await handler.Handle(new CreateClothesProductCommand
        {   
            Id = Guid.NewGuid(),
            ProductName = "productName",
            Price = 5900,
            OldPrice = 7900,
            Description = "description",
            InStock = 32,
            ImagePath = "/images/main/img.png",
            ImageMiniPath = "/images/main/img.png",
            SellerId = 1,
            ProductDetail = new ProductDetail
            {
                Article = 0,
                Brend = "",
                CountryOfManufacture = "",
                ModelFeatures = "",
                DecorativeElements = "",
                Equipment = "",
                QuantityPerPackage = 1,
                Composition = "",
                Color = ColorStatus.Black,
                TypeOfPackaging = TypeOfPackaging.Box,
            },
            ClothesProduct = new ClothesProduct
            {
                Neckline = Neckline.Horseshoe,
                TheCut = TheCut.Free,
                TypeOfPockets = TypeOfPockets.None,
                Gender = Gender.Man,
                Season = Season.Autumn, 
                TakingCareOfThings = "wfawfe jljkweaij wea",
                Sizes =
                [
                    ClothesSizes.XXXS, 
                    ClothesSizes.XXL, 
                    ClothesSizes.M
                ]
            }
        },
        CancellationToken.None);
        // Assert
        Assert.NotNull(
            await productRepository.GetByIdAsync(
                productId, CancellationToken.None));
    }
}*/