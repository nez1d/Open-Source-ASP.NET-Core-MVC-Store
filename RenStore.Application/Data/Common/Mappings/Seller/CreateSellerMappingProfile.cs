using AutoMapper;
using RenStore.Application.Entities.Seller.Command.Create;
using RenStore.Domain.Dto.Seller;

namespace RenStore.Application.Data.Common.Mappings.Seller;

public class CreateSellerMappingProfile : Profile
{
    public CreateSellerMappingProfile()
    {
        CreateMap<CreateSellerDto, CreateSellerCommand>();
        CreateMap<CreateSellerCommand, RenStore.Domain.Entities.Seller>();
    }
}