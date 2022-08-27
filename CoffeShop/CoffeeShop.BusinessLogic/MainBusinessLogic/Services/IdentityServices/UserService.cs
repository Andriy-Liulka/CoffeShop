using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;

public class UserService : IUserService
{
    private readonly CoffeeShopContext _context;

    public UserService(CoffeeShopContext context)
    {   
        _context = context;
    }
    
    public async Task<List<User>> GetAllAsync() => await _context.Users
        .Include(x=>x.Orders)
        .Include(x=>x.Role)
        .ToListAsync();

    public async Task<User?> GetAsync(int userId) => await _context.Users
        .Include(x=>x.Orders)
        .Include(x=>x.Role)
        .FirstOrDefaultAsync(x => x.Id.Equals(userId));

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