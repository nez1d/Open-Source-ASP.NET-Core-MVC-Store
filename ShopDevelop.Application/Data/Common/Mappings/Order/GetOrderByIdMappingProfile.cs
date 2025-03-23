using AutoMapper;
using ShopDevelop.Application.Entities.Orders.Queries.GetById;

namespace ShopDevelop.Application.Data.Common.Mappings.Order;

public class GetOrderByIdMappingProfile : Profile
{
    public GetOrderByIdMappingProfile()
    {
        CreateMap<Domain.Entities.Order, GetOrderByIdVm>();
    }
}