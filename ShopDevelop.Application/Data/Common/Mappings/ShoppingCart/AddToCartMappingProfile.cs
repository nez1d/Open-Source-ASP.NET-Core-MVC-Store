using AutoMapper;
using ShopDevelop.Application.Entities.ShoppingCart.Command.Add;
using ShopDevelop.Domain.Dto.ShoppingCart;

namespace ShopDevelop.Application.Data.Common.Mappings.ShoppingCart;

public class AddToCartMappingProfile : Profile
{
    public AddToCartMappingProfile()
    {
        CreateMap<AddToCartDto, AddToCartCommand>();
    }
}