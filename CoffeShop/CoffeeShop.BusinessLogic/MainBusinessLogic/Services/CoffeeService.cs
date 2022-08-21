using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic;


public class CoffeeService : ICoffeeService
{
    private readonly CoffeeShopContext _context;

    public CoffeeService(CoffeeShopContext context)
    {   
        _context = context;
    }

    public async Task<List<Coffee>> GetAll() => await _context.Coffees
            .Include(x => x.DiscountCoffees)
            .Include(x => x.OrderVolumeCoffees)
            .Include(x => x.BonusCoffees)
            .ToListAsync();
    public async Task<Coffee?> Get(int id) => await _context.Coffees.FirstOrDefaultAsync(x => x.Id.Equals(id));

}
