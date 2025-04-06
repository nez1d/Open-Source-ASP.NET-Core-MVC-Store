using MediatR;

namespace ShopDevelop.Application.Entities.ShoppingCart.Query.GetAll;

public class GetAllCartItemsQuery : IRequest<IList<GetAllCartItemsVm>>
{
}