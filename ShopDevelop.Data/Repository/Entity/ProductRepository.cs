/*using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using ShopDevelop.Data.Repository.Interfaces;

namespace ShopDevelop.Data.Repository.Entity
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<List<Product>> Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            return _applicationDbContext.Products
                .FirstOrDefault(p => p.Id == id);
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
*/