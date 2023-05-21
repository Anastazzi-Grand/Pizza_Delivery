using PizzaDelivery_V2.Domain.Entities;
using PizzaDelivery_V2.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V2.BLL.Interfaces
{
    public interface IProductService
    {
        Task<IBaseResponse<IEnumerable<Product>>> GetProducts();
        Task<IBaseResponse<Product>> GetProductById(int id);
        Task<IBaseResponse<Product>> GetProductByName(string name);
    }
}
