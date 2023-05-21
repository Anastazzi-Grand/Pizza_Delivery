using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.DAL.DAL
{
    public class DeliveryDAL
    {
        private readonly ApplicationContext _db;

        public DeliveryDAL(DbContextOptions<ApplicationContext> db)
        {
            _db = new ApplicationContext(db);
        }

        public async Task<List<Delivery>> GetAll()
        {
            return await _db.Delivery.ToListAsync();

        }

        public async Task<Delivery> Add(Delivery newDelivery)
        {
            var dbDelivery = new Delivery()
            {
                Id = newDelivery.Id,
                CourierEmployeeId = newDelivery.CourierEmployeeId,
                Date = newDelivery.Date,
            };

            await _db.Delivery.AddAsync(dbDelivery);
            await _db.SaveChangesAsync();
            return dbDelivery;
        }

        public async Task<Delivery?> Get(int id)
        {
            return await _db.Delivery.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Delivery?> Update(Delivery delivery)
        {
            var dbDelivery = await Get(delivery.Id);
            if (dbDelivery != null)
            {
                dbDelivery.CourierEmployeeId = delivery.CourierEmployeeId;
                dbDelivery.Date = delivery.Date;

                await _db.SaveChangesAsync();
                return dbDelivery;
            }
            else
            {
                return null;
            }
        }

        public async Task<Delivery?> Delete(int id)
        {
            var dbDelivery = await Get(id);

            if (dbDelivery != null)
            {
                _db.Delivery.Remove(dbDelivery);
                await _db.SaveChangesAsync();
                return dbDelivery;
            }
            else
            {
                return null;
            }
        }
    }
}
