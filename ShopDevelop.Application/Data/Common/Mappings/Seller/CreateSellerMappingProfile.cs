using AutoMapper;
using ShopDevelop.Application.Entities.Seller.Command.Create;
using ShopDevelop.Domain.Dto.Seller;

namespace ShopDevelop.Application.Data.Common.Mappings.Seller;

public class CreateSellerMappingProfile : Profile
{
    public CreateSellerMappingProfile()
    {
        CreateMap<CreateSellerDto, CreateSellerCommand>();
        CreateMap<CreateSellerCommand, Domain.Entities.Seller>();
    }
}