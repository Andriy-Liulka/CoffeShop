using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderVolumeCoffeeRepositories;

public class OrderVolumeCoffeeRepository : Repository<OrderVolumeCoffee>, IOrderVolumeCoffeeRepository
{
    public OrderVolumeCoffeeRepository(CoffeeShopContext context) : base(context) { }
    public async Task<OrderVolumeCoffee?> GetAsync(int id) 
        => await _context.OrderVolumeCoffees.FirstOrDefaultAsync(x=>x.Id.Equals(id)) 
           ?? throw new NullReferenceException();
}