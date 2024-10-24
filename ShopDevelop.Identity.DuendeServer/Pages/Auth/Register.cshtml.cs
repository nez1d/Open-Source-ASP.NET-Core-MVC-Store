using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopDevelop.Identity.DuendeServer.Models;
using ShopDevelop.Identity.DuendeServer.ViewModels;

namespace ShopDevelop.Identity.DuendeServer.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RegisterModel(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) =>
            (userManager, signInManager) = (_userManager, _signInManager);

        [BindProperty]
        public RegisterViewModel model { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Redirect("/");
                }
                ModelState.AddModelError(string.Empty, "Error occurred");
            }
            return Page();
        }
    }
}
