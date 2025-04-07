using ShopDevelop.Application.Repository;
using MediatR;

namespace ShopDevelop.Application.Services.Product;

public class ProductService
{
    public async Task<decimal> CalculateDiscountByPriceAsync(decimal price, decimal oldPrice)
    {
        return (price / oldPrice) * 100;
    }
    
    public async Task<uint> CreateArticulAsync()
    {
        Random random = new Random();
        return (uint)random.Next(100000000, 999999999);
    }
}