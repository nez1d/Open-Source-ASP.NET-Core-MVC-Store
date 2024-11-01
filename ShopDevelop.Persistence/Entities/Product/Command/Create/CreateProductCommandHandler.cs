using ShopDevelop.Application.Repository;
using MediatR;

namespace ShopDevelop.Application.Entities.Product.Commands.Create;

public class CreateProductCommandHandler 
    : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository productRepository;
    public CreateProductCommandHandler(IProductRepository productRepository) =>
        this.productRepository = productRepository;

    public async Task<Guid> Handle(CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        return await productRepository.Create(new 
            ShopDevelop.Domain.Models.Product
        {
            Id = request.Id,
            ProductName = request.ProductName,
            Price = request.Price,
            Description = request.Description,
            ShortDescription = request.ShortDescription,
            InStock = request.InStock,
            IsFavorite = request.IsFavorite,
            Category = request.Category
        });
    }
}