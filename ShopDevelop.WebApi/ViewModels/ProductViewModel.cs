using System.ComponentModel.DataAnnotations;
using ShopDevelop.Domain.Entities;

public class ProductViewModel
{
    public Guid Id { get; set; }
    public uint Article { get; set; }
    [Required(ErrorMessage = "Please enter product name!")]
    [Display(Name = "Product Name*")]
    [StringLength(100)]
    public string ProductName { get; set; }
    [Required(ErrorMessage = "Please enter product price!")]
    [Display(Name = "Product Price*")]
    public decimal Price { get; set; }
    public decimal? OldPrice { get; set; }
    [Required(ErrorMessage = "Please enter discount of a product!")]
    [Display(Name = "Product Discount*")]
    public int? Discount { get; set; }
    [Required(ErrorMessage = "Please enter product description!")]
    [Display(Name = "Product Description*")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Please enter product short description!")]
    [Display(Name = "Product Short Description*")]
    public string ShortDescription { get; set; }
    [Required(ErrorMessage = "Please enter stock of products!")]
    [Display(Name = "Product Name*")]
    public uint InStock { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsAvailable { get; set; }
    [Required(ErrorMessage = "Please enter product image!")]
    [Display(Name = "Product Image*")]
    public string ImagePath { get; set; }
    public string ImageMiniPath { get; set; }
    public double Rating { get; set; }
    public IEnumerable<Review>? Reviews { get; set; }
    public Guid ReviewId { get; set; }
    public ProductDetail Details { get; set; }
    [Required(ErrorMessage = "Please enter product category!")]
    [Display(Name = "Product Category*")]
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    public Seller Seller { get; set; }
    public Guid SellerId { get; set; }
}