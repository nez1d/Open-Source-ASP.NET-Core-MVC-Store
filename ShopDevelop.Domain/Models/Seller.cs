namespace ShopDevelop.Domain.Models
{
    public class Seller
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
