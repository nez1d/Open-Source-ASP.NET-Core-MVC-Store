using System.ComponentModel.DataAnnotations;

namespace RenStore.Identity.DuendeServer.WebAPI.Models;

public record LoginUserRequest(
    [Required] [EmailAddress] string? Email,
    [Required] [DataType(DataType.Password)] string? Password);
