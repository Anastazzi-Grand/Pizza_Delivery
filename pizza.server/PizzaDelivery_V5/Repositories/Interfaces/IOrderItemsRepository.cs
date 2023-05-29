using PizzaDelivery_V5.Entities.Entities;

namespace PizzaDelivery_V5.Repositories.Interfaces
{
    public interface IOrderItemsRepository : IEntityRepository<OrderItems>
    {
        OrderItems GetByName(string name);
    }
}
