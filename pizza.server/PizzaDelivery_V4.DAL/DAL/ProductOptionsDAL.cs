using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.DAL.DAL
{
    public class ProductOptionsDAL
    {
        private readonly ApplicationContext _db;

        public ProductOptionsDAL(DbContextOptions<ApplicationContext> db)
        {
            _db = new ApplicationContext(db);
        }

        public async Task<List<ProductOptions>> GetAll()
        {
            return await _db.ProductOptions.ToListAsync();
        }

        public async Task<ProductOptions> Add(ProductOptions newProductOptions)
        {
            var productOptions = new ProductOptions()
            {
                Id = newProductOptions.Id,
                OptionKey = newProductOptions.OptionKey,
                OptionValue = newProductOptions.OptionValue,
                Markup = newProductOptions.Markup,
                ProductPropertyId = newProductOptions.ProductPropertyId,
            };

            await _db.ProductOptions.AddAsync(productOptions);
            await _db.SaveChangesAsync();
            return productOptions;
        }

        public async Task<ProductOptions?> Get(int id)
        {
            return await _db.ProductOptions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductOptions?> Update(ProductOptions productOptions)
        {
            var dbProductOptions = await Get(productOptions.Id);
            if (dbProductOptions != null)
            {
                dbProductOptions.OptionKey = productOptions.OptionKey;
                dbProductOptions.OptionValue = productOptions.OptionValue;
                dbProductOptions.Markup = productOptions.Markup;
                dbProductOptions.ProductPropertyId = productOptions.ProductPropertyId;

                await _db.SaveChangesAsync();
                return dbProductOptions;
            }
            else
            {
                return null;
            }
        }

        public async Task<ProductOptions?> Delete(int id)
        {
            var dbProductOptions = await Get(id);

            if (dbProductOptions != null)
            {
                _db.ProductOptions.Remove(dbProductOptions);
                await _db.SaveChangesAsync();
                return dbProductOptions;
            }
            else
            {
                return null;
            }
        }
    }
}
