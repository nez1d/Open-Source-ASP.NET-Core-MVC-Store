using MediatR;

namespace ShopDevelop.Application.Entities.Seller.Queries.GetAll;

public class GetAllSellersListQuery : IRequest<IList<SellerLookupDto>>
{
}