using CoffeeShop.Domain.Entities.Identity;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.IdentityCredentialRepositories;

public interface IIdentityCredentialRepository : IRepository<IdentityCredential>
{
    public Task<IdentityCredential> GetAsync(string login);
}