using CoffeeShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role> GetAsync(string name);
}