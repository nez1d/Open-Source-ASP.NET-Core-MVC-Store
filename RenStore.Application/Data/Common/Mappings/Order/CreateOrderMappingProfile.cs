using AutoMapper;
using RenStore.Domain.Dto.Order;

namespace RenStore.Application.Data.Common.Mappings.Order;
 
public class CreateOrderMappingProfile : Profile
{
    public CreateOrderMappingProfile()
    {
        CreateMap<CreateOrderDto, CreateOrderCommand>();
        CreateMap<CreateOrderCommand, RenStore.Domain.Entities.Order>();
    }
}