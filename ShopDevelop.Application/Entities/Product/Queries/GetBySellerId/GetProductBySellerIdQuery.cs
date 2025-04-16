using MediatR;

namespace ShopDevelop.Application.Entities.Product.Queries.GetBySellerId;

public class GetProductBySellerIdQuery : IRequest<IList<GetProductBySellerIdVm>>
{
    public int SellerId { get; set; }
}