using AutoMapper;
using ShopDevelop.Application.Entities.Product.Commands.Create;
using ShopDevelop.Application.Entities.Product.Commands.Update;
using ShopDevelop.Application.Entities.Product.Queries.GetProduct;
using ShopDevelop.Domain.Dto.Product;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Entities.Products;

namespace ShopDevelop.Application.Data.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region CreateProductDto To Command
        CreateMap<CreateProductDto, CreateProductCommand>()
            .ForMember(model => model.ProductName, opt =>
                opt.MapFrom(item => item.ProductName))
            .ForMember(model => model.Price, opt => 
                opt.MapFrom(item => item.Price))
            .ForMember(model => model.OldPrice,opt => 
                opt.MapFrom(item => item.OldPrice))
            .ForMember(model => model.Description, opt => 
                opt.MapFrom(item => item.Description))
            .ForMember(model => model.InStock, opt => 
                opt.MapFrom(item => item.InStock))
            .ForMember(model => model.ImagePath, opt => 
                opt.MapFrom(item => item.ImagePath))
            .ForMember(model => model.ImageMiniPath, opt => 
                opt.MapFrom(item => item.ImageMiniPath))
            .ForMember(model => model.ImageMiniPath, opt => 
                opt.MapFrom(item => item.ImagesListPath))
            .ForMember(model => model.CategoryName, opt => 
                opt.MapFrom(item => item.CategoryName))
            .ForMember(model => model.SellerId, opt => 
                opt.MapFrom(item => item.SellerId))
            .ForMember(model => model.ProductDetail, opt =>
                opt.MapFrom(item => new ProductDetail
                {
                    Brend = item.Brend,
                    CountryOfManufacture = item.CountryOfManufacture,
                    ModelFeatures = item.ModelFeatures,
                    DecorativeElements = item.DecorativeElements,
                    Equipment = item.Equipment,
                    QuantityPerPackage = item.QuantityPerPackage,
                    Composition = item.Composition,
                    Color = item.Color,
                    TypeOfPackaging = item.TypeOfPackaging
                }))
            .ForMember(model => model.ClothesProduct, opt =>
                opt.MapFrom(item => new ClothesProduct
                {
                    Neckline = item.Neckline,
                    TheCut = item.TheCut,
                    TypeOfPockets = item.TypeOfPockets,
                    Gender = item.Gender,
                    Season = item.Season,
                    TakingCareOfThings = item.TakingCareOfThings,
                    Sizes = item.Sizes
                }));
        #endregion
        
        CreateMap<CreateProductCommand, Product>();
        
        #region UpdateProductDto To Command
        
        CreateMap<UpdateProductDto, UpdateProductCommand>()
            .ForMember(model => model.Id, opt => 
                opt.MapFrom(item => item.ProductId))
            .ForMember(model => model.ProductName, opt =>
                opt.MapFrom(item => item.ProductName))
            .ForMember(model => model.Price,
                opt => opt.MapFrom(item => item.Price))
            .ForMember(model => model.OldPrice,
                opt => opt.MapFrom(item => item.OldPrice))
            .ForMember(model => model.Description,
                opt => opt.MapFrom(item => item.Description))
            .ForMember(model => model.InStock,
                opt => opt.MapFrom(item => item.InStock))
            .ForMember(model => model.ImagePath,
                opt => opt.MapFrom(item => item.ImagePath))
            .ForMember(model => model.ImageMiniPath,
                opt => opt.MapFrom(item => item.ImageMiniPath))
            .ForMember(model => model.ImageMiniPath,
                opt => opt.MapFrom(item => item.ImagesListPath))
            .ForMember(model => model.CategoryName,
                opt => opt.MapFrom(item => item.CategoryName))
            .ForMember(model => model.SellerId,
                opt => opt.MapFrom(item => item.SellerId))
            .ForMember(model => model.ProductDetail, opt =>
                opt.MapFrom(item => new ProductDetail
                {
                    Brend = item.Brend,
                    CountryOfManufacture = item.CountryOfManufacture,
                    ModelFeatures = item.ModelFeatures,
                    DecorativeElements = item.DecorativeElements,
                    Equipment = item.Equipment,
                    QuantityPerPackage = item.QuantityPerPackage,
                    Composition = item.Composition,
                    Color = item.Color,
                    TypeOfPackaging = item.TypeOfPackaging
                }))
            .ForMember(model => model.ClothesProduct, opt =>
                opt.MapFrom(item => new ClothesProduct
                {
                    Neckline = item.Neckline,
                    TheCut = item.TheCut,
                    TypeOfPockets = item.TypeOfPockets,
                    Gender = item.Gender,
                    Season = item.Season,
                    TakingCareOfThings = item.TakingCareOfThings,
                    Sizes = item.Sizes
                }));
        #endregion
        
        #region Product To ProductVm

        CreateMap<Product, ProductVm>()

            #region Product Mapper
            .ForMember(model => model.ProductId, opt =>
                opt.MapFrom(product => product.Id))
            .ForMember(model => model.ProductName, opt =>
                opt.MapFrom(product => product.ProductName))
            .ForMember(model => model.Price, opt =>
                opt.MapFrom(product => product.Price))
            .ForMember(model => model.OldPrice, opt =>
                opt.MapFrom(product => product.OldPrice))
            .ForMember(model => model.Discount, opt =>
                opt.MapFrom(product => product.Discount))
            .ForMember(model => model.Description, opt =>
                opt.MapFrom(product => product.Description))
            .ForMember(model => model.InStock, opt =>
                opt.MapFrom(product => product.InStock))
            .ForMember(model => model.ImagePath, opt =>
                opt.MapFrom(product => product.ImagePath))
            .ForMember(model => model.ImageMiniPath, opt =>
                opt.MapFrom(product => product.ImageMiniPath))
            .ForMember(model => model.ImagesListPath, opt =>
                opt.MapFrom(product => product.ImagesListPath))
            .ForMember(model => model.Rating, opt =>
                opt.MapFrom(product => product.Rating))
            .ForMember(model => model.CategoryId, opt =>
                opt.MapFrom(product => product.CategoryId))
            .ForMember(model => model.CategoryName, opt =>
                opt.MapFrom(product => product.CategoryName))
            .ForMember(model => model.SellerId, opt =>
                opt.MapFrom(product => product.SellerId))
            .ForMember(model => model.SellerName, opt =>
                opt.MapFrom(product => product.SellerName))
            .ForMember(model => model.ProductDetailId, opt =>
                opt.MapFrom(product => product.ProductDetailId))
            .ForMember(model => model.ClothesProductId, opt =>
                opt.MapFrom(product => product.ClothesProductId))
            .ForMember(model => model.ShoesProductId, opt =>
                opt.MapFrom(product => product.ShoesProductId))

            #endregion

            #region Product Details Mapper

            .ForMember(model => model.Article, opt =>
                opt.MapFrom(product => product.ProductDetail.Article))
            .ForMember(model => model.Brend, opt =>
                opt.MapFrom(product => product.ProductDetail.Brend))
            .ForMember(model => model.CountryOfManufacture, opt =>
                opt.MapFrom(product => product.ProductDetail.CountryOfManufacture))
            .ForMember(model => model.ModelFeatures, opt =>
                opt.MapFrom(product => product.ProductDetail.ModelFeatures))
            .ForMember(model => model.DecorativeElements, opt =>
                opt.MapFrom(product => product.ProductDetail.DecorativeElements))
            .ForMember(model => model.Equipment, opt =>
                opt.MapFrom(product => product.ProductDetail.Equipment))
            .ForMember(model => model.QuantityPerPackage, opt =>
                opt.MapFrom(product => product.ProductDetail.QuantityPerPackage))
            .ForMember(model => model.Composition, opt =>
                opt.MapFrom(product => product.ProductDetail.Composition))
            .ForMember(model => model.Color, opt =>
                opt.MapFrom(product => product.ProductDetail.Color))
            .ForMember(model => model.TypeOfPackaging, opt =>
                opt.MapFrom(product => product.ProductDetail.TypeOfPackaging))
            .ForMember(model => model.TypeOfPackaging, opt =>
                opt.MapFrom(product => product.ProductDetail.TypeOfPackaging));

        #endregion
        

        #endregion
    }
}