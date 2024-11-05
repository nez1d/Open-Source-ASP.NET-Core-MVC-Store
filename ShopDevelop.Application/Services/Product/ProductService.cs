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

    public async Task AddNewProduct(Domain.Models.Product product)
    {
        await productRepository.Create(product);
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

    public async Task<decimal> DiscountCalculate(decimal price, decimal oldPrice)
    {
        throw new NotImplementedException();
    }

    public async Task<decimal> RatingCalculate()
    {
        throw new NotImplementedException();
    }

    public async Task<int> ReviewsCalculate()
    {
        throw new NotImplementedException();
    }
}