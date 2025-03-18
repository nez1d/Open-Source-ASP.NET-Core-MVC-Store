using MediatR;

namespace ShopDevelop.Application.Entities.Seller.Queries.GetById;

public class GetSellerByIdQuery : IRequest<GetSellerByIdVm>
{
    public int Id { get; set; }
}