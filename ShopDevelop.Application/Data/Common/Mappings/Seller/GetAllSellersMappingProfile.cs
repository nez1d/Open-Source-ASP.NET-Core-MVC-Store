using AutoMapper;
using ShopDevelop.Application.Entities.Seller.Queries.GetById;

namespace ShopDevelop.Application.Data.Common.Mappings.Seller;

public class GetAllSellersMappingProfile : Profile
{
    public GetAllSellersMappingProfile()
    {
        CreateMap<Domain.Entities.Seller, GetSellerByIdVm>();
    }
}