using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;

public class DiscountCoffeeService : IDiscountCoffeeService
{
    private readonly CoffeeShopContext _context;

    public DiscountCoffeeService(CoffeeShopContext context)
    {   
        _context = context;
    }
    
    public async Task<List<DiscountCoffee>> GetAllAsync() => await _context.DiscountCoffees
        .Include(x=>x.Coffee)
        .Include(x=>x.Discount)
        .ToListAsync();

    public async Task<DiscountCoffee?> GetAsync(int discountId,int coffeetId) => await _context.DiscountCoffees
        .Include(x=>x.Coffee)
        .Include(x=>x.Discount)
        .FirstOrDefaultAsync(x => x.DiscountId.Equals(discountId) && x.CoffeeId.Equals(coffeetId));

    public async Task CreateAsync(DiscountCoffee discountCoffee)
    {
        await _context.DiscountCoffees.AddAsync(discountCoffee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DiscountCoffee discountCoffee)
    {
        _context.DiscountCoffees.Update(discountCoffee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(DiscountCoffee discountCoffee)
    {
        _context.DiscountCoffees.Remove(discountCoffee);
        await _context.SaveChangesAsync();
    }
}