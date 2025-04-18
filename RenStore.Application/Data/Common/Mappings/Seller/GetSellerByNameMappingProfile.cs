using AutoMapper;
using RenStore.Application.Entities.Seller.Queries.GetByName;

namespace RenStore.Application.Data.Common.Mappings.Seller;

public class GetSellerByNameMappingProfile : Profile
{
    public GetSellerByNameMappingProfile()
    {
        CreateMap<RenStore.Domain.Entities.Seller, GetSellerByNameVm>();
    }
}