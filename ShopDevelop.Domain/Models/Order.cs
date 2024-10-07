namespace ShopDevelop.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string OrderTotal { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}