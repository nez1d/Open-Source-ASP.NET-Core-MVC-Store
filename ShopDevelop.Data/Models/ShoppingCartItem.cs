namespace ShopDevelop.Data.Models
{
    public class ShoppingCartItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public string Size { get; set; }

        public User User { get; set; }

        public string ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public Product? Product { get; set; }

        public int ProductId { get; set; }
    }
}