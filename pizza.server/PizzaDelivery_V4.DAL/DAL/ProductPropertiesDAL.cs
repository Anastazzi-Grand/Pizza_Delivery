using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.DAL.DAL
{
    public class ProductPropertiesDAL
    {
        private readonly ApplicationContext _db;

        public ProductPropertiesDAL(DbContextOptions<ApplicationContext> db)
        {
            _db = new ApplicationContext(db);
        }

        public async Task<List<ProductProperties>> GetAll()
        {
            return await _db.ProductProperties.ToListAsync();
        }

        public async Task<ProductProperties> Add(ProductProperties newProductProperties)
        {
            var productProperties = new ProductProperties()
            {
                Id = newProductProperties.Id,
                ProductId = newProductProperties.ProductId,
                PropertyName = newProductProperties.PropertyName,
            };

            await _db.ProductProperties.AddAsync(productProperties);
            await _db.SaveChangesAsync();
            return productProperties;
        }

        public async Task<ProductProperties?> Get(int id)
        {
            return await _db.ProductProperties.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductProperties?> Update(ProductProperties productProperties)
        {
            var dbProductProperties = await Get(productProperties.Id);
            if (dbProductProperties != null)
            {
                dbProductProperties.ProductId = productProperties.ProductId;
                dbProductProperties.PropertyName = productProperties.PropertyName;


                await _db.SaveChangesAsync();
                return dbProductProperties;
            }
            else
            {
                return null;
            }
        }

        public async Task<ProductProperties?> Delete(int id)
        {
            var dbProductProperties = await Get(id);

            if (dbProductProperties != null)
            {
                _db.ProductProperties.Remove(dbProductProperties);
                await _db.SaveChangesAsync();
                return dbProductProperties;
            }
            else
            {
                return null;
            }
        }
    }
}
