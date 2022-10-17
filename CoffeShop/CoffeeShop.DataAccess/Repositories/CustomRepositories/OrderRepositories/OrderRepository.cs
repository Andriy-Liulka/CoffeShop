using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderRepositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(CoffeeShopContext context) : base(context) { }

    public async Task<Order> GetAsync(long id)
        => await _context.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id))
           ?? throw new NullReferenceException();
}