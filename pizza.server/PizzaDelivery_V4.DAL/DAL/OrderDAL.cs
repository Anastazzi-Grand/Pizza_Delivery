using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.DAL.DAL
{
    public class OrderDAL
    {
        private readonly ApplicationContext _db;

        public OrderDAL(DbContextOptions<ApplicationContext> db)
        {
            _db = new ApplicationContext(db);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _db.Order.ToListAsync();
        }

        public async Task<Order> Add(Order newOrder)
        {
            var order = new Order()
            {
                Id = newOrder.Id,
                ClientId = newOrder.ClientId,
                OrderDate = newOrder.OrderDate,
                Status = newOrder.Status,
                DeliveryDate = newOrder.DeliveryDate,
                Payment = newOrder.Payment,
                CookEmployeeId = newOrder.CookEmployeeId,
                OperatorEmployeeId = newOrder.OperatorEmployeeId,
                CourierId = newOrder.CourierId,
                TotalPrice = newOrder.TotalPrice,
            };

            await _db.Order.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> Get(int id)
        {
            return await _db.Order.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order?> Update(Order order)
        {
            var dbOrder = await Get(order.Id);
            if (dbOrder != null)
            {
                dbOrder.ClientId = order.ClientId;
                dbOrder.OrderDate = order.OrderDate;
                dbOrder.Status = order.Status;
                dbOrder.DeliveryDate = order.DeliveryDate;
                dbOrder.Payment = order.Payment;
                dbOrder.CookEmployeeId = order.CookEmployeeId;
                dbOrder.OperatorEmployeeId = order.OperatorEmployeeId;
                dbOrder.CourierId = order.CourierId;
                dbOrder.TotalPrice = order.TotalPrice;

                await _db.SaveChangesAsync();
                return dbOrder;
            }
            else
            {
                return null;
            }
        }

        public async Task<Order?> Delete(int id)
        {
            var dbOrder = await Get(id);

            if (dbOrder != null)
            {
                _db.Order.Remove(dbOrder);
                await _db.SaveChangesAsync();
                return dbOrder;
            }
            else
            {
                return null;
            }
        }
    }
}
