namespace ShopDevelop.Domain.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Product Product { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}