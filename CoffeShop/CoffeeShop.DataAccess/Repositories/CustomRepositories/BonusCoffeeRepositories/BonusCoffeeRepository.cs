using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.BonusCoffeeRepositories;

public class BonusCoffeeRepository : IBonusCoffeeRepository
{
    private readonly CoffeeShopContext _context;

    public BonusCoffeeRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public async Task<BonusCoffee> GetAsync(int id)
        => await _context.BonusCoffees.FirstOrDefaultAsync(x => x.Id.Equals(id)) 
           ?? throw new NullReferenceException();
}