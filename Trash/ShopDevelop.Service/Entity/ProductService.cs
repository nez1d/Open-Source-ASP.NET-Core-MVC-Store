using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using ShopDevelop.Data.Repository.Interfaces;

namespace ShopDevelop.Service.Entity
{
    public class ProductService : IProductRepository<ProductP>
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductP>> Add(ProductP product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductP>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductP> GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public async void Remove(ProductP product)
        {
            throw new NotImplementedException();
        }
    }
}
