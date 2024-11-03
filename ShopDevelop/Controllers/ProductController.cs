using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Data.DataBase;

namespace ShopDevelop.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Item(int? id)
        {
            int _id;
            if (id.HasValue)
            {
                _id = id.Value;
            }
            else
            {
                _id = 0;
            }

            var productPage = _context.Products
                 .Where(i => i.Id == id);

            if (productPage == null)
            {
                return View();
            }

            return View(productPage);
        }
    }
}
