using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderRepositories;

public class OrderRepository : IOrderRepository
{
    private readonly CoffeeShopContext _context;

    public OrderRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public async Task<Order> GetAsync(int id)
        => await _context.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id))
           ?? throw new NullReferenceException();
}