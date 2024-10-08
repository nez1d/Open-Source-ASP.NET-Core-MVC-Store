namespace ShopDevelop.Domain.Models
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public uint Amount { get; set; }
        public string ShoppingCartId { get; set; }
        public Product Product { get; set; }
    }
}