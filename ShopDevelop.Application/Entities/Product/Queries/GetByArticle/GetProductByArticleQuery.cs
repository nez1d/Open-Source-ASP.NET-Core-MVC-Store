using MediatR;

namespace ShopDevelop.Application.Entities.Product.Queries.GetByArticle;

public class GetProductByArticleQuery : IRequest<GetProductByArticleVm>
{
    public int Article { get; set; }
}