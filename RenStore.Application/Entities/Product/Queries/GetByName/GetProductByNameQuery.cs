using MediatR;

namespace RenStore.Application.Entities.Product.Queries.GetByName;

public class GetProductByNameQuery : IRequest<IList<GetProductByNameVm>>
{
    public string Name { get; set; }
}