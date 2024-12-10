using MediatR;

namespace ShopDevelop.Application.Entities.Category.Commands.Create;

public class CreateCategoryCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
}