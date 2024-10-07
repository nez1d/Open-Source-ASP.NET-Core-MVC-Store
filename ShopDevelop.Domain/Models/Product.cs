namespace ShopDevelop.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public int Article { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public int? Discount { get; set; }
        public string ShortDescription { get; set; }
        public int Count { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsAvailable { get; set; }
        public int InStock { get; set; }
        public string Description { get; set; }
        public Seller Seller { get; set; }
        public Guid SellerId { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public string ImagePath { get; set; }
        public string ImageMiniPath { get; set; }
        public int Rating { get; set; }
        public List<Review> Reviews { get; set; }
        public Guid ReviewId { get; set; }
        public ProductDetails Details { get; set; }
    }
}