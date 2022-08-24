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
        .ThenInclude(x=>x.Discount)

        .Include(x => x.OrderVolumeCoffees)
        .ThenInclude(x=>x.Order)
        
        .Include(x => x.OrderVolumeCoffees)
        .ThenInclude(x=>x.Volume)

        .Include(x => x.BonusCoffees)
        .ThenInclude(x=>x.Volume)
        
        .ToListAsync();

    public async Task<Coffee?> GetAsync(int id) => await _context.Coffees
        .Include(x => x.DiscountCoffees)
        .ThenInclude(x=>x.Discount)

        .Include(x => x.OrderVolumeCoffees)
        .ThenInclude(x=>x.Order)
        
        .Include(x => x.OrderVolumeCoffees)
        .ThenInclude(x=>x.Volume)

        .Include(x => x.BonusCoffees)
        .ThenInclude(x=>x.Volume)
        
        .FirstOrDefaultAsync(x => x.Id.Equals(id));

    public async Task CreateAsync(Coffee coffee)
    {
        await _context.Coffees.AddAsync(coffee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Coffee coffee)
    {
        _context.Coffees.Update(coffee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Coffee coffee)
    {
        _context.Coffees.Remove(coffee);
        await _context.SaveChangesAsync();
    }
}
