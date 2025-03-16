using AutoMapper;
using ShopDevelop.Application.Entities.Seller.Command.Create;

namespace ShopDevelop.Application.Data.Common.Mappings.Seller;

public class CreateSellerMappingProfile : Profile
{
    public CreateSellerMappingProfile()
    {
        CreateMap<CreateSellerCommand, Domain.Entities.Seller>();
    }
}