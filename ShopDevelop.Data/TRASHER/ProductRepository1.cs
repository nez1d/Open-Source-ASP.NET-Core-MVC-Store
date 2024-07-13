using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopDevelop.Data.TRASHER
{
    public class ProductRepository1
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository1(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        // Получить все продукты.
        /*public IEnumerable<Product> GetAll() => _context.Products.Include(c => c.Name);*/

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
                .ToListAsync();
        }

        // Получить один продукт.
        public Product Get(int id) => _context.Products.FirstOrDefault(p => p.Id == id);

        public Product Add(int id, string name, string seller)
        {
            var product = new Product
            {

                Name = "T-Shirt 1",
                ShortDescription = "",
                Seller = "From Russia",
                ImagePath = "",
                Price = 3900,
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
    }
}
