/*using AutoMapper;
using ShopDevelop.Application.Data.Common.Mappings;

namespace ShopDevelop.Application.Entities.Product.Queries.GetAllProducts;

public class ProductLookuptDto : IMapWith<Domain.Entities.Product>
{
    public Guid Id { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Product, ProductLookuptDto>()
            .ForMember(product => product.Id, opt =>
                opt.MapFrom(product => product.Id));
    }
}*/