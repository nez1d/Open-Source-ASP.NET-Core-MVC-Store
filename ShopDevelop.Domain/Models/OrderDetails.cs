namespace ShopDevelop.Domain.Models
{
    public class OrderDetails
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public uint Amount { get; set; }
    }
}