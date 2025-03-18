using AutoMapper;
using ShopDevelop.Application.Entities.Seller.Queries.GetByName;

namespace ShopDevelop.Application.Data.Common.Mappings.Seller;

public class GetSellerByNameMappingProfile : Profile
{
    public GetSellerByNameMappingProfile()
    {
        CreateMap<Domain.Entities.Seller, GetSellerByNameVm>();
    }
}