using Microsoft.AspNetCore.Mvc;

namespace ShopDevelop.Web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
