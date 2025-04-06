using MediatR;

namespace ShopDevelop.Application.Entities.ShoppingCart.Query.GetTotalPrice;

public class GetTotalShoppingCartPriceQuery : IRequest<GetTotalShoppingCartPriceVm>
{
    public string UserId { get; set; }
}