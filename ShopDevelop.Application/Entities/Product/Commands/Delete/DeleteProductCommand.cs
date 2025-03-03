using MediatR;

namespace ShopDevelop.Application.Entities.Product.Commands.Delete;

public class DeleteProductCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}