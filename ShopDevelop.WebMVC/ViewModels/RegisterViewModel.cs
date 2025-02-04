using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.WebMVC.ViewModels;

public record RegisterViewModel(
    [Required] [EmailAddress] string Email,
    [Required] [DataType(DataType.Password)] string Password,
    [Required] [DataType(DataType.Password)] [property: Compare("Password", ErrorMessage = "")] string ConfirmPassword);
