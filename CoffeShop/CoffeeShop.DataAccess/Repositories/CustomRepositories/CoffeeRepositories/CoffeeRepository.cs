using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;

public class CoffeeRepository : ICoffeeRepository
{
    private readonly CoffeeShopContext _context;
    public CoffeeRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public async Task<Coffee> GetAsync(int id)
        => await _context.Coffees.FirstOrDefaultAsync(x => x.Id.Equals(id)) 
           ?? throw new NullReferenceException();
}