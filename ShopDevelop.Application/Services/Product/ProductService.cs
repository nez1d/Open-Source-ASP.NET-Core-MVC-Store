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

    public async Task<bool> AddNewProductAsync(Domain.Models.Product product)
    {
        var result = await productRepository
            .Create(product) != Guid.Empty;

        if (result)
            return true;

        return false;
    }

    public async Task EditProductAsync(Domain.Models.Product product)
    {
        var model = await productRepository.GetById(product.Id);
        await productRepository.Update(product);
    }

    public Task DeleteProductAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteProduct(Guid id)
    {
        await productRepository.Delete(id);
    }

    public async Task<IEnumerable<MiniProductLookupDto>> GetAllProductsAsync()
    {
        try
        {
            var products = await mediator.Send(new GetMiniProductListQuery());
            return products;
        }
        catch (Exception ex) { }

        return null;
    }

    public async Task<Domain.Models.Product> GetByIdAsync(Guid? id)
    {
        try
        {
            return await productRepository.GetById(id);
        }
        catch (Exception ex) { }

        return null;
    }

    public async Task<decimal> CalculateDiscountByPriceAsync(decimal price, decimal oldPrice)
    {
        return (price / oldPrice) * 100;
    }

    public async Task<decimal> CalculateDiscountByPercentAsync(decimal price, decimal discountPercent)
    {
        return price * discountPercent;
    }

    public async Task<decimal> RatingCalculateAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> ReviewsCalculateAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateActiculeAsync()
    {
        throw new NotImplementedException();
    }
}