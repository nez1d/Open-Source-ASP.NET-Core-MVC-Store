namespace ShopDevelop.Data.Models
{
    public class DbSession
    {
        public Guid DbSessionId { get; set; }

        public string SessionData { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LastAccessed { get; set; }

        public int UserId { get; set; }
    }
}
