using MediatR;

namespace ShopDevelop.Application.Entities.Category.Queries.GetCategoryByName;

public class GetCategoryByNameQuery : IRequest<CategoryByNameVm>
{
    public string Name { get; set; }
}