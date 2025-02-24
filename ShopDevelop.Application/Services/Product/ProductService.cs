using ShopDevelop.Application.Repository;
using MediatR;

namespace ShopDevelop.Application.Services.Product;

public class ProductService : IProductService
{
    /*public async Task<bool> AddNewProductAsync(Domain.Entities.Product product, string categoryName, Guid sellerId)
    {
        var dicount = Convert.ToInt32(
            await CalculateDiscountByPriceAsync(
            price: product.Price, 
            oldPrice: product.OldPrice));
        
        var article = Convert.ToUInt32(await CreateActiculeAsync());
        var category = await categoryRepository.GetByName(categoryName);
        var seller = await sellerRepository.GetById(sellerId);
        
        var data = new Domain.Entities.Product
        {
            ProductName = product.ProductName,
            Price = product.Price,
            OldPrice = product.OldPrice,
            Discount = dicount,
            Description = product.Description,
            InStock = product.InStock,
            ImagePath = product.ImagePath,
            ImageMiniPath = product.ImageMiniPath,
            Category = category,
            /*CategoryId = category.Id,#1#
            Seller = seller,
            SellerId = seller.Id,
        };
        
        var result = await productRepository
            .Create(data, default) != Guid.Empty;

        if (result)
            return true;

        return false;
    }*/

    /*public async Task EditProductAsync(Domain.Entities.Product product)
    {
        var model = await productRepository.GetById(product.Id);
        await productRepository.Update(product);
    }

    public Task DeleteProductAsync(Guid id)
    {
        throw new NotImplementedException();
    }*/

    /*public async Task<IEnumerable<MiniProductLookupDto>> GetAllProductsAsync()
    {
        try
        {
            var products = await mediator.Send(new GetMiniProductListQuery());
            return products;
        }
        catch (Exception ex) { }

        return null; 
    }*/

    /*public async Task<Domain.Entities.Product> GetByIdAsync(Guid? id)
    {
        try
        {
            return await productRepository.GetById(id);
        }
        catch (Exception ex) { }

        return null;
    }*/

    public async Task<decimal> CalculateDiscountByPriceAsync(decimal price, decimal oldPrice)
    {
        return (price / oldPrice) * 100;
    }

    /*public async Task<decimal> CalculateDiscountByPercentAsync(decimal price, decimal discountPercent)
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
    }*/

    public async Task<uint> CreateArticulAsync()
    {
        Random random = new Random();
        
        return (uint)random.Next(100000000, 999999999);
    }
}