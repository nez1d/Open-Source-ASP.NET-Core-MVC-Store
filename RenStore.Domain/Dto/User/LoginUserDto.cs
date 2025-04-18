using System.ComponentModel.DataAnnotations;

namespace RenStore.Domain.Dto.User;

public record LoginUserDto(
    [Required] string? Email, 
    [Required] string? Password);