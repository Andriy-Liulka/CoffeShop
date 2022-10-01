using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.RoleRepositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(CoffeeShopContext context) : base(context) { }

    public async Task<Role> GetAsync(string name)
        => await _context.Roles.FirstOrDefaultAsync(x=>x.Name.Equals(name)) 
           ?? throw new NullReferenceException();
}