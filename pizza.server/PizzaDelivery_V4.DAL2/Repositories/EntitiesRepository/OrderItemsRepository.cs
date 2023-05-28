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
    public class OrderItemsRepository : IOrderItemsRepository
    {
        public readonly PDDbContext _db;

        public OrderItemsRepository(PDDbContext db)
        {
            _db = db;
        }
        public async Task<OrderItems> Add(OrderItems orderItems)
        {
            var result = await _db.OrderItems.AddAsync(orderItems);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var OrderItems = await GetById(id);
            _db.Remove(OrderItems);
            await _db.SaveChangesAsync();
            return OrderItems != null ? true : false;
        }

        public async Task<IEnumerable<OrderItems>> Get()
        {
            return await _db.OrderItems.ToListAsync();
        }

        public async Task<OrderItems> GetById(int id)
        {
            return await _db.OrderItems.FirstOrDefaultAsync(p => p.Id == id);
        }

        public OrderItems GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderItems> Update(OrderItems orderItems)
        {
            var result = _db.OrderItems.Update(orderItems);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        async Task<OrderItems> IEntityRepository<OrderItems>.GetByNameEntity(string name)
        {
            throw new NotImplementedException();
        }
    }
}
