using ShopDevelop.Domain.Entities;

namespace ShopDevelop.WebMVC.ViewModels;

public record CatalogViewModel(
    string Id,
    string ProductName,
    string Price,
    Seller Seller,
    decimal Rating,
    uint ReviewCount,
    string ImageMiniPath
);