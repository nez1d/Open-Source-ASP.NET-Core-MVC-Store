﻿namespace ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;

public class ProductMiniLookupDto
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public double? Rating { get; set; }
    public string ImageMiniPath { get; set; }
    public string SellerName { get; set; }

    public ProductMiniLookupDto(
        Guid productId, 
        string productName, 
        decimal price, 
        double? rating,
        string imageMiniPath, 
        string sellerName)
    {
        Id = productId;
        ProductName = productName;
        Price = price;
        Rating = rating;
        ImageMiniPath = imageMiniPath;
        SellerName = sellerName;
    }
}