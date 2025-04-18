using MediatR;

namespace RenStore.Application.Entities.Product.Queries.GetByNovelty;

public class GetProductByNoveltyQuery : IRequest<IList<GetProductByNoveltyVm>>
{
    public bool Descending { get; set; }
}