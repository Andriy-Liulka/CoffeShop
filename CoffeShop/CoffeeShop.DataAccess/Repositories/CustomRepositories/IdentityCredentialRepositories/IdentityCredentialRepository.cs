using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.IdentityCredentialRepositories;

public class IdentityCredentialRepository : Repository<IdentityCredential>, IIdentityCredentialRepository
{
    private readonly CoffeeShopContext _context;
    public IdentityCredentialRepository(CoffeeShopContext context):base(context)
    {
        _context = context;
    }

    public async Task<IdentityCredential> GetAsync(string login)
        => await _context.IdentityCredentials.FirstOrDefaultAsync(x => x.Id.Equals(login)) 
           ?? throw new NullReferenceException();
}