using MediatR;

namespace ShopDevelop.Application.Entities.ShoppingCart.Query.GetByUserId;

public class GetShoppingCartItemsByUserIdQuery : IRequest<IList<GetShoppingCartItemsByUserIdVm>>
{
    public string UserId { get; set; }
}