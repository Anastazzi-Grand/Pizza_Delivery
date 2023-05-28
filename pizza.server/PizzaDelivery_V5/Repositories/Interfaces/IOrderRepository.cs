using PizzaDelivery_V5.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V5.Repositories.Interfaces
{
    public interface IOrderRepository : IEntityRepository<Order>
    {
        Order GetByName(string name);
    }
}
