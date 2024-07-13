/*using Microsoft.EntityFrameworkCore;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using ShopDevelop.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDevelop.Data.Repository
{
    public class CartProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CartProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Product>> Add(Product entity)
        {
            
        }

        public async Task<ShoppingCart> GetById(int id)
        {
            return await _applicationDbContext.ShoppingCart
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        *//*public async Task<List<Product>> Get(int id)
        {
            return await _applicationDbContext.ShoppingCart
                .AsNoTracking()
                .Where(p => p.Id == id)
                .ToListAsync();
        }*//*

        public async IEnumerable<Product> GetAll()
        {
        }

        public async void Remove(Product entity)
        {
            
        }
    }
}
*/