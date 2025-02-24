using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Domain.Dto.User;

public record LoginUserDto(
    [Required] string? Email, 
    [Required] string? Password);