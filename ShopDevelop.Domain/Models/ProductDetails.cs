namespace ShopDevelop.Domain.Models
{
    public class ProductDetails
    {
        Product Product { get; set; }
        public Guid ProductId { get; set; }
        public List<string> Sizes { get; set; }
        public string Composition { get; set; }
    }
}
