using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V2.DAL.Repositories.Interfaces;
using PizzaDelivery_V2.Domain.Entities;

namespace PizzaDelivery_V2.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {

        
        public readonly ApplicationContext _db;

        public ProductRepository(ApplicationContext db)
        {
            _db = db;
        }
       
        public async Task<Product> AddEntity(Product product)
        {
            var result = await _db.Product.AddAsync(product);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteEntity(int id)
        {
            var product = await GetEntityById(id);
            _db.Remove(product);
            await _db.SaveChangesAsync();
            return product != null ? true : false;
        }

        public Product GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetEntity()
        {
            return await _db.Product.ToListAsync();
        }

        public async Task<Product> GetEntityById(int id)
        {
            return await _db.Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetEntityByName(string name)
        {
            return await _db.Product.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<Product> UpdateEntity(Product product)
        {
            var result = _db.Product.Update(product);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
    }
}

