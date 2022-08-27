using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;

public class RoleService : IRoleService
{
    private readonly CoffeeShopContext _context;

    public RoleService(CoffeeShopContext context)
    {   
        _context = context;
    }
    
    public async Task<List<Role>> GetAllAsync() => await _context.Roles
        .Include(x=>x.Users)

        .ToListAsync();

    public async Task<Role?> GetAsync(int userId) => await _context.Roles
        .Include(x=>x.Users)
        
        .FirstOrDefaultAsync(x => x.Id.Equals(userId));
}