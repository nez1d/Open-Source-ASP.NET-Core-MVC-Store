using AutoMapper;
using ShopDevelop.Domain.Enums;

namespace ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;

public class ProductDetailVm
{
    public Guid Id { get; set; }
    public uint Article { get; set; }
    public string Brend { get; set; }
    public string? CountryOfManufacture { get; set; }
    public string? ModelFeatures { get; set; } 
    public string? DecorativeElements { get; set; }
    public string? Equipment { get; set; }
    public uint? QuantityPerPackage { get; set; }
    public string? Composition { get; set; }
    public ColorStatus? Color { get; set; }
    public TypeOfPackaging? TypeOfPackaging { get; set; }
    public Guid ProductId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.ProductDetail, ProductDetailVm>()
            .ForMember(model => model.Article, opt =>
                opt.MapFrom(product => product.Article))
            .ForMember(model => model.Brend, opt =>
                opt.MapFrom(product => product.Brend))
            .ForMember(model => model.CountryOfManufacture, opt =>
                opt.MapFrom(product => product.CountryOfManufacture))
            .ForMember(model => model.ModelFeatures, opt =>
                opt.MapFrom(product => product.ModelFeatures))
            .ForMember(model => model.DecorativeElements, opt =>
                opt.MapFrom(product => product.DecorativeElements))
            .ForMember(model => model.Equipment, opt =>
                opt.MapFrom(product => product.Equipment))
            .ForMember(model => model.QuantityPerPackage, opt =>
                opt.MapFrom(product => product.QuantityPerPackage))
            .ForMember(model => model.Composition, opt =>
                opt.MapFrom(product => product.Composition))
            .ForMember(model => model.Color, opt =>
                opt.MapFrom(product => product.Color))
            .ForMember(model => model.TypeOfPackaging, opt =>
                opt.MapFrom(product => product.TypeOfPackaging))
            .ForMember(model => model.TypeOfPackaging, opt =>
                opt.MapFrom(product => product.TypeOfPackaging))
            .ForMember(model => model.ProductId, opt =>
                opt.MapFrom(product => product.ProductId));
    }
}