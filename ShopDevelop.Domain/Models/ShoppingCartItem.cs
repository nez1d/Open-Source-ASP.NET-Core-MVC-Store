namespace ShopDevelop.Domain.Models
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public uint Amount { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Product Product { get; set; }
        public string ApplicationUserId { get; set; }
        
        /*public ApplicationUser ApplicationUser { get; set; }*/
    }
}