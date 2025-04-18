using MediatR;

namespace RenStore.Application.Entities.Seller.Command.Delete;

public class DeleteSellerCommand : IRequest
{
    public int Id { get; set; }
}