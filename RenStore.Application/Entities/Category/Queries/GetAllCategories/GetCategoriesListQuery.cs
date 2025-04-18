using MediatR;
using RenStore.Application.Entities.Product.Queries.GetMinimizedProducts;

namespace RenStore.Application.Entities.Category.Queries.GetAllCategories;

public class GetCategoriesListQuery : IRequest<List<CategoryLookupDto>>
{
}