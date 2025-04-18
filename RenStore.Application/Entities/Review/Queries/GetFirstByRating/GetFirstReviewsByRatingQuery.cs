using MediatR;

namespace RenStore.Application.Entities.Review.Queries.GetFirstByRating;

public class GetFirstReviewsByRatingQuery : IRequest<IList<GetFirstReviewsByRatingVm>>
{
    public Guid ProductId { get; set; }
    public int Count { get; set; }
}