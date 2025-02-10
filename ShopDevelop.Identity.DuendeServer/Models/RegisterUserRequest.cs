using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Identity.DuendeServer.Models;

public record RegisterUserRequest(
    [Required] [EmailAddress] string? Email,
    [Required] [DataType(DataType.Password)] string? Password);

