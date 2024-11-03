using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;

namespace ShopDevelop.Application.Services.Product;

public interface IProductService
{
    Task<IEnumerable<MiniProductLookupDto>> GetAllProducts();
    Task<Domain.Models.Product> GetById(Guid? id);
}
