using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Identity.DuendeServer.Models;

public record RegisterUserRequest(
    [Required] string? Email,
    [Required] string? Password);
