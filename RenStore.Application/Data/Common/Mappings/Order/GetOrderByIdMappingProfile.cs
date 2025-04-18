using AutoMapper;
using RenStore.Application.Entities.Orders.Queries.GetById;

namespace RenStore.Application.Data.Common.Mappings.Order;

public class GetOrderByIdMappingProfile : Profile
{
    public GetOrderByIdMappingProfile()
    {
        CreateMap<RenStore.Domain.Entities.Order, GetOrderByIdVm>();
    }
}