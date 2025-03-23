using AutoMapper;
using ShopDevelop.Application.Entities.Orders.Commands.Create;

namespace ShopDevelop.Application.Data.Common.Mappings.Order;
 
public class CreateOrderMappingProfile : Profile
{
    public CreateOrderMappingProfile()
    {
        CreateMap<CreateOrderCommand, Domain.Entities.Order>();
    }
}