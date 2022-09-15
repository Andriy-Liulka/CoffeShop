using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.BonusCoffeeRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.RoleRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class BonusCoffeeService : IBonusCoffeeService
{
    private readonly IBonusCoffeeRepository _bonusCoffeeRepository;

    public BonusCoffeeService(IBonusCoffeeRepository bonusCoffeeRepository)
    {
        _bonusCoffeeRepository = bonusCoffeeRepository;
    }

    public async Task<IEnumerable<BonusCoffee>> GetAllAsync()
        => await _bonusCoffeeRepository.GetAllAsync();

    public async Task<BonusCoffee?> GetAsync(int id)
        => await _bonusCoffeeRepository.GetAsync(id);

    public async Task CreateAsync(BonusCoffee bonusCoffee)
        => await _bonusCoffeeRepository.CreateAsync(bonusCoffee);

    public async Task UpdateAsync(BonusCoffee bonusCoffee)
        => await _bonusCoffeeRepository.UpdateAsync(bonusCoffee);

    public async Task DeleteAsync(BonusCoffee bonusCoffee)
        => await _bonusCoffeeRepository.DeleteAsync(bonusCoffee);
}