using AutoMapper;
using RenStore.Application.Entities.ShoppingCart.Command.Add;
using RenStore.Domain.Dto.ShoppingCart;

namespace RenStore.Application.Data.Common.Mappings.ShoppingCart;

public class AddToCartMappingProfile : Profile
{
    public AddToCartMappingProfile()
    {
        CreateMap<AddToCartDto, AddToCartCommand>();
    }
}