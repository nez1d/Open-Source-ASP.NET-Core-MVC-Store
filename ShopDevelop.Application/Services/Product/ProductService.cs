using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Application.Repository;
using MediatR;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Services.Product;

public class ProductService : IProductService
{
    private readonly ISender mediator;
    private readonly IProductRepository productRepository;    
    private readonly ICategoryRepository categoryRepository;
    private readonly ISellerRepository sellerRepository;
    public ProductService(ISender mediator,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        ISellerRepository sellerRepository) =>
        (this.mediator, this.productRepository, this.categoryRepository, 
            this.sellerRepository) = 
        (mediator, productRepository, categoryRepository, sellerRepository);

    public async Task<bool> AddNewProductAsync(Domain.Models.Product product, string categoryName, Guid sellerId)
    {
        var dicount = Convert.ToInt32(await CalculateDiscountByPriceAsync(
            price: product.Price, 
            oldPrice: product.OldPrice));
        
        var article = Convert.ToUInt32(await CreateActiculeAsync());

        var category = await categoryRepository.GetByName(categoryName);

        var seller = await sellerRepository.GetById(sellerId);
        
        var data = new Domain.Models.Product
        {
            ProductName = product.ProductName,
            Price = product.Price,
            OldPrice = product.OldPrice,
            Discount = dicount,
            Description = product.Description,
            ShortDescription = product.ShortDescription,
            Article = article,
            InStock = product.InStock,
            IsAvailable = product.IsAvailable,
            ImagePath = "/",
            ImageMiniPath = "/",
            Category = category,
            CategoryId = Guid.Parse("0193b8a1-2d86-788d-a529-a4b93935047e"),
            Seller = seller,
            SellerId = seller.Id,
        };
        
        var result = await productRepository
            .Create(data) != Guid.Empty;

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
        Random random = new Random();
        
        return random.Next(100000000, 999999999);
    }
}