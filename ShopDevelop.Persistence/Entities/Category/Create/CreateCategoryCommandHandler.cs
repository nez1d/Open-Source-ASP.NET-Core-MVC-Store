using MediatR;
using ShopDevelop.Application.Entities.Category.Commands.Create;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Category.Create;

public class CreateCategoryCommandHandler
    : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryRepository categoryRepository;
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository) =>
        this.categoryRepository = categoryRepository;

    public async Task<Guid> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        return await categoryRepository.Create(
            new ShopDevelop.Domain.Models.Category
            {
                Name = request.Name,
                Description = request.Description,
                ImagePath = request.ImagePath 
            });
    }
}