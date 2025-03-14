using AutoMapper;
using ShopDevelop.Application.Entities.Product.Commands.Update;
using ShopDevelop.Domain.Dto.Product;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Entities.Products;

namespace ShopDevelop.Application.Data.Common.Mappings;

public class UpdateProductMappingProfile : Profile
{
    public UpdateProductMappingProfile()
    {
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
    }
}