using MediatR;
using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;

namespace ShopDevelop.Application.Entities.Category.Queries.GetAllCategories;

public class GetCategoriesListQuery : IRequest<List<CategoryLookupDto>>
{
}