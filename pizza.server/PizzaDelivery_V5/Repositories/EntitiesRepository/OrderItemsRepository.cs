using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V5.Entities.Entities;
using PizzaDelivery_V5.Repositories.Interfaces;

namespace PizzaDelivery_V5.Repositories.EntitiesRepository
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

        public Task<OrderItems> GetById(int id)
        {
            throw new NotImplementedException();
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
