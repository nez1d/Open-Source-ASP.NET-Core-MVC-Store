using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Domain.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsUpdated  { get; set; }
        public string Message { get; set;  }
        [Range(5, Int32.MaxValue)] public decimal Rating { get; set; }
        public IEnumerable<string> ImagesUrls { get; set; }
        public uint LikesCount { get; set; }
        public List<string> UsersLikedIds { get; set; }
    }
}