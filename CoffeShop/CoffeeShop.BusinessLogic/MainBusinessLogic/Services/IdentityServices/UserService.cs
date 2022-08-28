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

    public async Task CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}