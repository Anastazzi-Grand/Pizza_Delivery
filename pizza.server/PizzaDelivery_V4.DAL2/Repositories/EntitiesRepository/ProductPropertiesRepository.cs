using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V4.DAL2.Repositories.Interfaces;
using PizzaDelivery_V4.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.DAL2.Repositories.EntitiesRepository
{
    public class ProductPropertiesRepository : IProductPropertiesRepository
    {
        public readonly PDDbContext _db;

        public ProductPropertiesRepository(PDDbContext db)
        {
            _db = db;
        }
        public async Task<ProductProperties> Add(ProductProperties productProperties)
        {
            var result = await _db.ProductProperties.AddAsync(productProperties);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var ProductProperties = await GetById(id);
            _db.Remove(ProductProperties);
            await _db.SaveChangesAsync();
            return ProductProperties != null ? true : false;
        }

        public async Task<IEnumerable<ProductProperties>> Get()
        {
            return await _db.ProductProperties.ToListAsync();
        }

        public async Task<ProductProperties> GetById(int id)
        {
            return await _db.ProductProperties.FirstOrDefaultAsync(p => p.Id == id);
        }

        public ProductProperties GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductProperties> Update(ProductProperties productProperties)
        {
            var result = _db.ProductProperties.Update(productProperties);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        async Task<ProductProperties> IEntityRepository<ProductProperties>.GetByNameEntity(string name)
        {
            return await _db.ProductProperties.FirstOrDefaultAsync(p => p.PropertyName == name);
        }
    }
}
