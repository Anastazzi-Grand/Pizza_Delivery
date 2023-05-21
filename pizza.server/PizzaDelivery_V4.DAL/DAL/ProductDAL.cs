using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.DAL.DAL
{
    public class ProductDAL
    {
        private readonly ApplicationContext _db;

        public ProductDAL(DbContextOptions<ApplicationContext> db)
        {
            _db = new ApplicationContext(db);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _db.Product.ToListAsync();
        }

        public async Task<Product> Add(Product newProduct)
        {
            var product = new Product()
            {
                Id = newProduct.Id,
                Group = newProduct.Group,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Image = newProduct.Image,
                CookingTime = newProduct.CookingTime,
            };

            await _db.Product.AddAsync(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> Get(int id)
        {
            return await _db.Product.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product?> Update(Product product)
        {
            var dbProduct = await Get(product.Id);
            if (dbProduct != null)
            {
                dbProduct.Group = product.Group;
                dbProduct.Name = product.Name;
                dbProduct.Price = product.Price;
                dbProduct.Image = product.Image;
                dbProduct.CookingTime = product.CookingTime;

                await _db.SaveChangesAsync();
                return dbProduct;
            }
            else
            {
                return null;
            }
        }

        public async Task<Product?> Delete(int id)
        {
            var dbProduct = await Get(id);

            if (dbProduct != null)
            {
                _db.Product.Remove(dbProduct);
                await _db.SaveChangesAsync();
                return dbProduct;
            }
            else
            {
                return null;
            }
        }
    }
}
