using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderVolumeCoffeeRepositories;

public class OrderVolumeCoffeeRepository : IOrderVolumeCoffeeRepository
{
    private readonly CoffeeShopContext _context;
    public OrderVolumeCoffeeRepository(CoffeeShopContext context)
    {
        _context = context;
    }
    public async Task<OrderVolumeCoffee?> GetAsync(int id) 
        => await _context.OrderVolumeCoffees.FirstOrDefaultAsync(x=>x.Id.Equals(id)) 
           ?? throw new NullReferenceException();
}