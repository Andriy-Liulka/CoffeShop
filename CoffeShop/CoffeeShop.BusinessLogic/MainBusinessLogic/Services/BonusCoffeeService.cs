using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic;

public class BonusCoffeeService
{
    private readonly CoffeeShopContext _context;

    public BonusCoffeeService(CoffeeShopContext context)
    {   
        _context = context;
    }
    
    public async Task<List<BonusCoffee>> GetAllAsync() => await _context.BonusCoffees
        .Include(x=>x.Coffee)
        .ThenInclude(x=>x.BonusCoffees)
        
        .Include(x=>x.Coffee)
        .ThenInclude(x=>x.DiscountCoffees)
        
        .Include(x=>x.Coffee)
        .ThenInclude(x=>x.OrderVolumeCoffees)
        
        .Include(x=>x.Volume)

        .ToListAsync();

    public async Task<BonusCoffee?> GetAsync(int id) => await _context.BonusCoffees
        .Include(x=>x.Coffee)
        .ThenInclude(x=>x.BonusCoffees)
        
        .Include(x=>x.Coffee)
        .ThenInclude(x=>x.DiscountCoffees)
        
        .Include(x=>x.Coffee)
        .ThenInclude(x=>x.OrderVolumeCoffees)
        
        .Include(x=>x.Volume)

        .FirstOrDefaultAsync(x => x.Id.Equals(id));

    public async Task CreateAsync(BonusCoffee bonusCoffee)
    {
        await _context.BonusCoffees.AddAsync(bonusCoffee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BonusCoffee bonusCoffee)
    {
        _context.BonusCoffees.Update(bonusCoffee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(BonusCoffee bonusCoffee)
    {
        _context.BonusCoffees.Remove(bonusCoffee);
        await _context.SaveChangesAsync();
    }
}