using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Identity.DuendeServer.ViewModels;

public class LoginViewModel
{
    [Required]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    public bool? RememberMe { get; set; } = true;
    /*public string? ReturnUrl { get; set; }*/
}