namespace ShopDevelop.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Category { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public DateTime OrderPlaced { get; set; }

        public double OrderPrice { get; set; }

        public string Seller { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool IsPosted { get; set; }

        public int Count { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
