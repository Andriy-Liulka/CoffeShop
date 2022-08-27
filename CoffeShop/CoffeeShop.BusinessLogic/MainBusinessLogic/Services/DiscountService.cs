using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class DiscountService
{
    private readonly CoffeeShopContext _context;

    public DiscountService(CoffeeShopContext context)
    {   
        _context = context;
    }
    
    public async Task<List<Discount>> GetAllAsync() => await _context.Discounts
        .Include(x=>x.DiscountCoffees)
        .ThenInclude(x=>x.Coffee)

        .Include(x=>x.DiscountCoffees)
        .ThenInclude(x=>x.Discount)
        
        .ToListAsync();

    public async Task<Discount?> GetAsync(int id) => await _context.Discounts
        .Include(x=>x.DiscountCoffees)
        .ThenInclude(x=>x.Coffee)

        .Include(x=>x.DiscountCoffees)
        .ThenInclude(x=>x.Discount)

        .FirstOrDefaultAsync(x => x.Id.Equals(id));

    public async Task CreateAsync(Discount discount)
    {
        await _context.Discounts.AddAsync(discount);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Discount discount)
    {
        _context.Discounts.Update(discount);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Discount discount)
    {
        _context.Discounts.Remove(discount);
        await _context.SaveChangesAsync();
    }
}