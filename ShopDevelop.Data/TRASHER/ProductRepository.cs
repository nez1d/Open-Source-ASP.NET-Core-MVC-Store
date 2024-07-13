using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using ShopDevelop.Data.Repository.Interfaces;
using System.Data.Entity;
using System.Runtime.InteropServices;

namespace ShopDevelop.Data.TRASHER
{
    public class ProductRepository
    /*: IRepository<Product>*/
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Product AddProduct(int id, string name, string seller, decimal price)
        {
            var product = new Product
            {
                Id = id,
                Name = name,
                ShortDescription = "",
                Seller = seller,
                ImagePath = "",
                Price = price,
            };
            _applicationDbContext.Products.Add(product);
            _applicationDbContext.SaveChanges();
            return product;
        }

        public async Task<List<Product>> GetProduct()
        {
            return await _applicationDbContext.Products
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Product entity)
        {
            throw new NotImplementedException();
        }


    }
}
