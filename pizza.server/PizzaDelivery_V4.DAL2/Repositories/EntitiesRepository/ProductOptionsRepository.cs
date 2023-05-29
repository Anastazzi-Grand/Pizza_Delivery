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
    public class ProductOptionsRepository : IProductOptionsRepository
    {
        public readonly PDDbContext _db;

        public ProductOptionsRepository(PDDbContext db)
        {
            _db = db;
        }
        public async Task<ProductOptions> Add(ProductOptions productOptions)
        {
            var result = await _db.ProductOptions.AddAsync(productOptions);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var ProductOptions = await GetById(id);
            _db.Remove(ProductOptions);
            await _db.SaveChangesAsync();
            return ProductOptions != null ? true : false;
        }

        public async Task<IEnumerable<ProductOptions>> Get()
        {
            return await _db.ProductOptions.ToListAsync();
        }

        public async Task<ProductOptions> GetById(int id)
        {
            return await _db.ProductOptions.FirstOrDefaultAsync(p => p.Id == id);
        }

        public ProductOptions GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductOptions> Update(ProductOptions productOptions)
        {
            var result = _db.ProductOptions.Update(productOptions);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        async Task<ProductOptions> IEntityRepository<ProductOptions>.GetByNameEntity(string name)
        {
            throw new NotImplementedException();
        }
    }
}
