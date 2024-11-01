using MediatR;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Entities.Product.Commands.Create;

public class CreateProductCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public uint InStock { get; set; }
    public bool IsFavorite { get; set; }
    public Category Category { get; set; }
}