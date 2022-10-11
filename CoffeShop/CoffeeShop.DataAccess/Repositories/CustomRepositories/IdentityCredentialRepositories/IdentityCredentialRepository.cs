using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.IdentityCredentialRepositories;

public class IdentityCredentialRepository : Repository<IdentityCredential>, IIdentityCredentialRepository
{
    public IdentityCredentialRepository(CoffeeShopContext context) : base(context) { }

    public async Task<IdentityCredential> GetAsync(string login)
        => await _context.IdentityCredentials.FirstOrDefaultAsync(x => x.Login.Equals(login)) 
           ?? throw new NullReferenceException();
}