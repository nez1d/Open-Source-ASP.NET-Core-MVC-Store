using System.Collections;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.WebMVC.ViewModels;

public record CatalogViewModel(
    string Id,
    string ProductName,
    string Price,
    Seller Seller,
    decimal Rating,
    uint ReviewCount,
    string ImagePath
);
