using MediatR;

namespace ShopDevelop.Application.Entities.Category.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<CategoryByIdVm>
{
    public int Id { get; set; }
}