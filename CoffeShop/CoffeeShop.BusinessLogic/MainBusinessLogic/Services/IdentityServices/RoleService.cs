using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.RoleRepositories;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;

public class RoleService : IRoleService
{
    private readonly IRepository<Role> _repository;
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRepository<Role> repository,IRoleRepository roleRepository)
    {
        _repository = repository;
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
        => await _repository.GetAllAsync(); 

    public async Task<Role?> GetAsync(int userId) 
    => await _roleRepository.GetAsync(userId); 
}