using MediatR;

namespace ShopDevelop.Application.Entities.Seller.Queries.GetByName;

public class GetSellerByNameQuery : IRequest<GetSellerByNameVm>
{
    public string Name { get; set; }
}