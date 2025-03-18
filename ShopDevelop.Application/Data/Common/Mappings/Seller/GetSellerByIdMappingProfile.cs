using AutoMapper;
using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Application.Entities.Seller.Queries.GetById;

namespace ShopDevelop.Application.Data.Common.Mappings.Seller;

public class GetSellerByIdMappingProfile : Profile
{
    public GetSellerByIdMappingProfile()
    {
        CreateMap<Domain.Entities.Seller, GetSellerByIdVm>();
    }
}