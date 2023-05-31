using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V5.Entities.Entities;
using PizzaDelivery_V5.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V5.Repositories.EntitiesRepository
{
    public class OrderRepository : IOrderRepository
    {
        public readonly PDDbContext _db;

        public OrderRepository(PDDbContext db)
        {
            _db = db;
        }
        public async Task<Order> Add(Order newOrder)
        {
            var user = await _db.Client.FirstOrDefaultAsync(u => u.PhoneNumber == newOrder.PhoneNumber);
            if (user == null)
            {
                user = new Client()
                {
                    PhoneNumber = newOrder.PhoneNumber,
                    Address = newOrder.Address,
                    FullName = newOrder.FullName,
                };
                await _db.Client.AddAsync(user);
                await _db.SaveChangesAsync();
            }

            newOrder.ClientId = user.Id;
            var order = await _db.Order.AddAsync(newOrder);
            await _db.SaveChangesAsync();
            return order.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var Order = await GetById(id);
            _db.Remove(Order);
            await _db.SaveChangesAsync();
            return Order != null ? true : false;
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _db.Order.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _db.Order.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Order GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Update(Order order)
        {
            var result = _db.Order.Update(order);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        async Task<Order> IEntityRepository<Order>.GetByNameEntity(string name)
        {
            throw new NotImplementedException();
        }
    }
}
