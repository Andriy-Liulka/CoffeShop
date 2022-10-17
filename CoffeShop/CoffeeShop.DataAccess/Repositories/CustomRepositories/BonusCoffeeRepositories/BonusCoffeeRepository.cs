using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.BonusCoffeeRepositories;

public class BonusCoffeeRepository : Repository<BonusCoffee>, IBonusCoffeeRepository
{
    public BonusCoffeeRepository(CoffeeShopContext context) : base(context) { }

    public async Task<BonusCoffee> GetAsync(long id)
        => await _context.BonusCoffees.FirstOrDefaultAsync(x => x.Id.Equals(id)) 
           ?? throw new NullReferenceException();
}