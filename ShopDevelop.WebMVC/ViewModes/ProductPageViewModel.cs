﻿using ShopDevelop.Domain.Models;

namespace ShopDevelop.WebMVC.ViewModes;

public class ProductPageViewModel
{
    public Guid? Id { get; set; }
    public int? Article { get; set; }
    public string? ProductName { get; set; }
    public decimal? Price { get; set; }
    public decimal? OldPrice { get; set; }
    public int? Discount { get; set; }
    public string? Description { get; set; }
    public uint? InStock { get; set; }
    public bool? IsFavorite { get; set; }
    public bool? IsAvailable { get; set; }
    public string? ImagePath { get; set; }
    public double? Rating { get; set; }
    public IEnumerable<Review>? Reviews { get; set; }
    public ProductDetail? Details { get; set; }
    public Category? Category { get; set; }
    public Guid? CategoryId { get; set; }
    public Seller? Seller { get; set; }
    public Guid? SellerId { get; set; }
}