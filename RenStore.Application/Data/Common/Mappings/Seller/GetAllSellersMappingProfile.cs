using AutoMapper;
using RenStore.Application.Entities.Seller.Queries.GetById;

namespace RenStore.Application.Data.Common.Mappings.Seller;

public class GetAllSellersMappingProfile : Profile
{
    public GetAllSellersMappingProfile()
    {
        CreateMap<RenStore.Domain.Entities.Seller, GetSellerByIdVm>();
    }
}