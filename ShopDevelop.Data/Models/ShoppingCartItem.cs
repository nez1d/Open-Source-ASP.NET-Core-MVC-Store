namespace ShopDevelop.Data.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int? Amount { get; set; }

        public string ShoppingCartId { get; set; }

        public Product Product { get; set; }
    }
}