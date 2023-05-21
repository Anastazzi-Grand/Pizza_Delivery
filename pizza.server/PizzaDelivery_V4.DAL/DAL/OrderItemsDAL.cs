using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.DAL.DAL
{
    public class OrderItemsDAL
    {
        private readonly ApplicationContext _db;

        public OrderItemsDAL(DbContextOptions<ApplicationContext> db)
        {
            _db = new ApplicationContext(db);
        }

        public async Task<List<OrderItems>> GetAll()
        {
            return await _db.OrderItems.ToListAsync();
        }

        public async Task<OrderItems> Add(OrderItems newOrderItems)
        {
            var orderItems = new OrderItems()
            {
                Id = newOrderItems.Id,
                OrderNumber = newOrderItems.OrderNumber,
                Count = newOrderItems.Count,
                ProductId = newOrderItems.ProductId,
                ProductPropertyId = newOrderItems.ProductPropertyId,
                ProductOptionId = newOrderItems.ProductOptionId,
            };

            await _db.OrderItems.AddAsync(orderItems);
            await _db.SaveChangesAsync();
            return orderItems;
        }

        public async Task<OrderItems?> Get(int id)
        {
            return await _db.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OrderItems?> Update(OrderItems orderItems)
        {
            var dbOrderItems = await Get(orderItems.Id);
            if (dbOrderItems != null)
            {
                dbOrderItems.OrderNumber = orderItems.OrderNumber;
                dbOrderItems.Count = orderItems.Count;
                dbOrderItems.ProductId = orderItems.ProductId;
                dbOrderItems.ProductPropertyId = orderItems.ProductPropertyId;
                dbOrderItems.ProductOptionId = orderItems.ProductOptionId;

                await _db.SaveChangesAsync();
                return dbOrderItems;
            }
            else
            {
                return null;
            }
        }

        public async Task<OrderItems?> Delete(int id)
        {
            var dbOrderItems = await Get(id);

            if (dbOrderItems != null)
            {
                _db.OrderItems.Remove(dbOrderItems);
                await _db.SaveChangesAsync();
                return dbOrderItems;
            }
            else
            {
                return null;
            }
        }
    }
}
