using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Application.Repository;
using MediatR;

namespace ShopDevelop.Application.Services.Product;

public class ProductService : IProductService
{
    private readonly ISender mediator;
    private readonly IProductRepository productRepository;
    public ProductService(ISender mediator,
        IProductRepository productRepository) =>
        (this.mediator, this.productRepository) = 
        (mediator, productRepository);

    public async Task<bool> AddNewProduct(Domain.Models.Product product)
    {
        var result = await productRepository.Create(product);

        if (result != null)
        {
            return true;
        }
        return false;
    }

    public async Task EditProduct(Domain.Models.Product product)
    {
        await productRepository.Update(product);
    }

    public async Task DeleteProduct(Guid id)
    {
        await productRepository.Delete(id);
    }

    public async Task<IEnumerable<MiniProductLookupDto>> GetAllProducts()
    {
        try
        {
            var products = await mediator.Send(new GetMiniProductListQuery());
            return products;
        }
        catch (Exception ex) { }

        return null;
    }

    public async Task<Domain.Models.Product> GetById(Guid? id)
    {
        try
        {
            return await productRepository.GetById(id);
        }
        catch (Exception ex) { }

        return null;
    }

    public async Task<decimal> CalculateDiscountByPrice(decimal price, decimal oldPrice)
    {
        return (price / oldPrice) * 100;
    }

    public async Task<decimal> CalculateDiscountByPercent(decimal price, decimal discountPercent)
    {
        return price * discountPercent;
    }

    public async Task<decimal> RatingCalculate()
    {
        throw new NotImplementedException();
    }

    public async Task<int> ReviewsCalculate()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateActicule()
    {
        throw new NotImplementedException();
    }
}