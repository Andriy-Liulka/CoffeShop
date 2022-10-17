using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;

public class CoffeeRepository : Repository<Coffee>, ICoffeeRepository
{
    public CoffeeRepository(CoffeeShopContext context) : base(context) { }

    public async Task<Coffee> GetAsync(long id)
        => await _context.Coffees.FirstOrDefaultAsync(x => x.Id.Equals(id)) 
           ?? throw new NullReferenceException();
}