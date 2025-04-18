using MediatR;

namespace RenStore.Application.Entities.Seller.Queries.GetAll;

public class GetAllSellersListQuery : IRequest<IList<SellerLookupDto>>
{
}