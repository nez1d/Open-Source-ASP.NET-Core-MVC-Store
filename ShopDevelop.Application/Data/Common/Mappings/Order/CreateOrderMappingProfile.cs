using AutoMapper;
using ShopDevelop.Application.Entities.Orders.Commands.Create;
using ShopDevelop.Domain.Dto.Order;

namespace ShopDevelop.Application.Data.Common.Mappings.Order;
 
public class CreateOrderMappingProfile : Profile
{
    public CreateOrderMappingProfile()
    {
        CreateMap<CreateOrderDto, CreateOrderCommand>();
        CreateMap<CreateOrderCommand, Domain.Entities.Order>();
    }
}