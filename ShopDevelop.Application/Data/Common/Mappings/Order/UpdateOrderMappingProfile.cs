using AutoMapper;
using ShopDevelop.Application.Entities.Orders.Commands.Update;
using ShopDevelop.Domain.Dto.Order;

namespace ShopDevelop.Application.Data.Common.Mappings.Order;

public class UpdateOrderMappingProfile : Profile
{
    public UpdateOrderMappingProfile()
    {
        CreateMap<UpdateOrderDto, UpdateOrderCommand>();
    }
}