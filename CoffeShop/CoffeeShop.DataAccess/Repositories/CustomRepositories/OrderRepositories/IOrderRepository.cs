using CoffeeShop.Domain.Entities;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderRepositories;

public interface IOrderRepository : IRepository<Order>
{
    public Task<Order> GetAsync(long id);
}