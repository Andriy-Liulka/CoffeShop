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

    public async Task<List<Coffee>> GetAll()
    {
        return await _context.Coffees
            .Include(x => x.Discount_Coffees)
            .Include(x => x.Order_Volume_Coffees)
            .Include(x => x.BonusCoffees)
            .ToListAsync();
    }
}