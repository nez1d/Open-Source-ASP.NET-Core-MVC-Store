using ShopDevelop.Application.Repository;
using MediatR;

namespace ShopDevelop.Application.Services.Product;

public class ProductService : IProductService
{

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