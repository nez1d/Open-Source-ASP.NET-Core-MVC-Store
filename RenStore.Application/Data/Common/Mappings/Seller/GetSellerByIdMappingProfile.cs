using AutoMapper;
using RenStore.Application.Entities.Seller.Queries.GetById;
using RenStore.Application.Entities.Product.Queries.GetMinimizedProducts;

namespace RenStore.Application.Data.Common.Mappings.Seller;

public class GetSellerByIdMappingProfile : Profile
{
    public GetSellerByIdMappingProfile()
    {
        CreateMap<RenStore.Domain.Entities.Seller, GetSellerByIdVm>();
    }
}