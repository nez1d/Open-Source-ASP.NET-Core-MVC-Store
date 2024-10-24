namespace ShopDevelop.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}