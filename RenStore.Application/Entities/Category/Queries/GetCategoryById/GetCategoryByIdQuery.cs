using MediatR;

namespace RenStore.Application.Entities.Category.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<CategoryByIdVm>
{
    public int Id { get; set; }
}