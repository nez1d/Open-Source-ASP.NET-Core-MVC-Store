using MediatR;

namespace RenStore.Application.Entities.Category.Queries.GetCategoryByName;

public class GetCategoryByNameQuery : IRequest<CategoryByNameVm>
{
    public string Name { get; set; }
}