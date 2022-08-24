using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;


public class CoffeeService : ICoffeeService
{
    private readonly CoffeeShopContext _context;

    public CoffeeService(CoffeeShopContext context)
    {   
        _context = context;
    }

    public async Task<List<Coffee>> GetAllAsync() => await _context.Coffees
        .Include(x => x.DiscountCoffees)
        .Include(x => x.OrderVolumeCoffees)
        .Include(x => x.BonusCoffees)
        .ToListAsync();

    public async Task<Coffee?> GetAsync(int id) => await _context.Coffees
        .Include(x => x.DiscountCoffees).ThenInclude(x=>x.)
        .Include(x => x.OrderVolumeCoffees)
        .Include(x => x.BonusCoffees)
        .FirstOrDefaultAsync(x => x.Id.Equals(id));

}
