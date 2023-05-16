namespace PizzaDelivery_V2.DAL.Repositories
{
    public interface IEntityRepository<T>
    {
        public Task<IEnumerable<T>> GetEntity();
        public Task<T> GetEntityById(int id);
        public Task<T> GetEntityByName(string name);
        public Task<T> AddEntity(T entity);
        public Task<T> UpdateEntity(T entity);
        public Task<bool> DeleteEntity(int id);
    }
}
