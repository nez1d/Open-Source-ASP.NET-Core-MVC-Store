namespace ShopDevelop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public IEnumerable<ProductP> Products { get; set; }
    }
}
