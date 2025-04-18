using MediatR;

namespace RenStore.Application.Entities.ShoppingCart.Query.GetAll;

public class GetAllCartItemsQuery : IRequest<IList<GetAllCartItemsVm>>
{
}