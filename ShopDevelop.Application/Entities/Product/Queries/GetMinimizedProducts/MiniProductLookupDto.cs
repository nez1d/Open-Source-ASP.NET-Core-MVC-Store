using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;

public class MiniProductLookupDto
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public decimal? OldPrice { get; set; }
    public int? Discount { get; set; }
    public Seller Seller { get; set; }
    public string ImageMiniPath { get; set; }

    public MiniProductLookupDto(Guid id, string productName, decimal price, decimal? oldPrice, int? discount,
        Seller seller, string imageMiniPath)
    {
        Id = id;
        ProductName = productName;
        Price = price;
        OldPrice = oldPrice;
        Discount = discount;
        Seller = seller;
        ImageMiniPath = imageMiniPath;
    }
}