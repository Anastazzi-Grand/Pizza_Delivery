using PizzaDelivery_V4.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.DAL2.Repositories.Interfaces
{
    public interface IProductOptionsRepository : IEntityRepository<ProductOptions>
    {
        ProductOptions GetByName(string name);
    }
}
