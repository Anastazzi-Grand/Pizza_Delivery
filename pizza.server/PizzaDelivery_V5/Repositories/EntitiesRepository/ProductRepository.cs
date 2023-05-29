using PizzaDelivery_V5.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V5.Repositories.Interfaces;

namespace PizzaDelivery_V5.Repositories.EntitiesRepository
{
    public class ProductRepository : IProductRepository
    {
        public readonly PDDbContext _db;

        public ProductRepository(PDDbContext db)
        {
            _db = db;
        }
        public async Task<Product> Add(Product product)
        {
            var result = await _db.Product.AddAsync(product);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await GetById(id);
            _db.Remove(product);
            await _db.SaveChangesAsync();
            return product != null ? true : false;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _db.Product.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Product GetByName(string name)
        {
            throw new NotImplementedException();
        }



        public async Task<Product> GetByNameEntity(string name)
        {
            var lowerName = name.ToLower();
            return await _db.Product.FirstOrDefaultAsync(p => p.Name.ToLower() == lowerName);
        }

        public async Task<Product> Update(Product product)
        {
            var result = _db.Product.Update(product);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

    }
}
