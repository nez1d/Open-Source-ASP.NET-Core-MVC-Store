using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopDevelop.Identity.DuendeServer.Pages.Auth
{
    public class GoogleModel : PageModel
    {
        public void OnGet(string ReturnUrl)
        {
            /*if(!Url.IsLocalUrl(ReturnUrl))
            {
                throw new Exception("Invalid return URL");
            }

            var proterties = new AuthenticationProperties
            {
                RedirectUri = ReturnUrl
            };

            return Challenge(proterties, "Google");*/
        }
    }
}
