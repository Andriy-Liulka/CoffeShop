using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderVolumeCoffeeRepositories;

public interface IOrderVolumeCoffeeRepository : IRepository<OrderVolumeCoffee>
{
    Task<OrderVolumeCoffee?> GetAsync(int id);
}