namespace ShopDevelop.Domain.Models
{
    public class ProductDetail
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public IEnumerable<string> Sizes { get; set; }
        public string Composition { get; set; }
    }
}
