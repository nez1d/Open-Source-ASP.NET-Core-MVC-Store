namespace ShopDevelop.Data.Models
{
    public class ProductP
    {
        public int Id { get; set; }

        public int Article { get; set; }

        public string Name { get; set; }

        public string Size { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Seller { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public decimal OldPrice { get; set; }

        public int Discount { get; set; }

        public string Composition { get; set; }

        public ushort Rating { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsAvailable { get; set; }

        public int InStock { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public string ImagePath { get; set; }

        public string ImageMiniPath { get; set; }
    }
}
