using CoffeeShop.Domain.Entities;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderRepositories;

public interface IOrderRepository
{
    public Task<Order> GetAsync(int id);
}