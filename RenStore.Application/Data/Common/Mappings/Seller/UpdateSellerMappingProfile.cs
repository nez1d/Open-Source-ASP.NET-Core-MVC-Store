using AutoMapper;
using RenStore.Application.Entities.Seller.Command.Update;
using RenStore.Domain.Dto.Seller;

namespace RenStore.Application.Data.Common.Mappings.Seller;

public class UpdateSellerMappingProfile : Profile
{
    public UpdateSellerMappingProfile()
    {
        CreateMap<UpdateSellerDto, UpdateSellerCommand>();
    }
}