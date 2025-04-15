using MediatR;

namespace ShopDevelop.Application.Entities.Product.Queries.GetSortedByPrice;

public class GetSortedProductsByPriceQuery : IRequest<IList<GetSortedProductsByPriceVm>>
{
    public decimal? MaxPrice { get; set; }
    public decimal? MinPrice { get; set; }
    public bool Descending { get; set; }
}