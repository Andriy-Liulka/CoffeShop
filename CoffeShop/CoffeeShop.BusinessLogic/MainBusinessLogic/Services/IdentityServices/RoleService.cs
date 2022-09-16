using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.RoleRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IActionResult> GetAllAsync()
        => new OkObjectResult(await _roleRepository.GetAllAsync());

    public async Task<IActionResult> GetAsync(string name)
        => new OkObjectResult(await _roleRepository.GetAsync(name)); 
}