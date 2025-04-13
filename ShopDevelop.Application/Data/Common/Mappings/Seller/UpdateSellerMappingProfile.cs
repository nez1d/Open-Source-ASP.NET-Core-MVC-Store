using AutoMapper;
using ShopDevelop.Application.Entities.Seller.Command.Update;
using ShopDevelop.Domain.Dto.Seller;

namespace ShopDevelop.Application.Data.Common.Mappings.Seller;

public class UpdateSellerMappingProfile : Profile
{
    public UpdateSellerMappingProfile()
    {
        CreateMap<UpdateSellerDto, UpdateSellerCommand>();
    }
}