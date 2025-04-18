using MediatR;

namespace RenStore.Application.Entities.Review.Queries.GetFirstByCreatedDate;

public class GetFirstReviewsByDateQuery : IRequest<IList<GetFirstReviewsByDateVm>>
{
    public Guid ProductId { get; set; }
    public int Count { get; set; }
}