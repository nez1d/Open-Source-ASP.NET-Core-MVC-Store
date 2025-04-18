using AutoMapper;
using RenStore.Application.Entities.Orders.Commands.Update;
using RenStore.Domain.Dto.Order;

namespace RenStore.Application.Data.Common.Mappings.Order;

public class UpdateOrderMappingProfile : Profile
{
    public UpdateOrderMappingProfile()
    {
        CreateMap<UpdateOrderDto, UpdateOrderCommand>();
    }
}