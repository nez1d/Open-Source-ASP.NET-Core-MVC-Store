using MediatR;

namespace ShopDevelop.Application.Entities.Seller.Command.Delete;

public class DeleteSellerCommand : IRequest
{
    public int Id { get; set; }
}