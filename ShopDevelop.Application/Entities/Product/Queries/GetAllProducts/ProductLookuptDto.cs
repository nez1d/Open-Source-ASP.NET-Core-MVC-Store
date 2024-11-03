using AutoMapper;
using ShopDevelop.Application.Data.Common.Mappings;

namespace ShopDevelop.Application.Entities.Product.Queries.GetAllProducts;

public class ProductLookuptDto : IMapWith<Domain.Models.Product>
{
    public Guid Id { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Models.Product,
            ProductLookuptDto>()
            .ForMember(product => product.Id, opt =>
                opt.MapFrom(product => product.Id));
    }
}
