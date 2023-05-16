using PizzaDelivery_V2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V2.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Product GetByName(string name);
    }
}
