using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;

public class UserRepository : Repository<User>,IUserRepository
{
    private readonly CoffeeShopContext _context;
    public UserRepository(CoffeeShopContext context):base(context)
    {
        _context = context;
    }

    public async Task<User?> GetAsync(string login)
        => await _context.Users.FirstOrDefaultAsync(x=>x.Login.Equals(login));

    public async Task<User?> GetFullAsync(string login)
    =>await _context.Users
        .Include(x=>x.Role)
        .Include(x=>x.IdentityCredential)
        .FirstOrDefaultAsync(x=>x.Login.Equals(login));
}