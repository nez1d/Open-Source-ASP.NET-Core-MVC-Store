using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.WebMVC.ViewModels;

public record LoginViewModel(
    [Required] [EmailAddress] string? Email,
    [Required] [DataType(DataType.Password)] string? Password,
    [Required] bool RememberMe = false);
