using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V5.Repositories.Interfaces
{
    public interface IEntityRepository<T>
    {
        public Task<IEnumerable<T>> Get();
        public Task<T> GetById(int id);
        public Task<T> GetByNameEntity(string name);
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<bool> Delete(int id);
    }
}
