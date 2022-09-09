using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;

public class UserRepository : IUserRepository
{
    private readonly CoffeeShopContext _context;
    public UserRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public async Task<User> GetAsync(string login)
        => await _context.Users.FirstOrDefaultAsync(x=>x.Login.Equals(login)) 
           ?? throw new NullReferenceException();
}