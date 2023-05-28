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
    public class DeliveryRepository : IDeliveryRepository
    {
        public readonly PDDbContext _db;

        public DeliveryRepository(PDDbContext db)
        {
            _db = db;
        }
        public async Task<Delivery> Add(Delivery delivery)
        {
            var result = await _db.Delivery.AddAsync(delivery);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var Delivery = await GetById(id);
            _db.Remove(Delivery);
            await _db.SaveChangesAsync();
            return Delivery != null ? true : false;
        }

        public async Task<IEnumerable<Delivery>> Get()
        {
            return await _db.Delivery.ToListAsync();
        }

        public async Task<Delivery> GetById(int id)
        {
            return await _db.Delivery.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Delivery GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Delivery> Update(Delivery delivery)
        {
            var result = _db.Delivery.Update(delivery);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        async Task<Delivery> IEntityRepository<Delivery>.GetByNameEntity(string name)
        {
            throw new NotImplementedException();
        }
    }
}
