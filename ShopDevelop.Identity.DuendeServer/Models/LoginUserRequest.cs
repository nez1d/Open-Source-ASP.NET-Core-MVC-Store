using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Identity.DuendeServer.Models;

public record LoginUserRequest(
    [Required] string? Email,
    [Required] string? Password);
