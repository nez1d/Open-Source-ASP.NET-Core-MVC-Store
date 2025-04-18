using MediatR;

namespace RenStore.Application.Entities.Category.Commands.Create;

public class CreateCategoryCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}