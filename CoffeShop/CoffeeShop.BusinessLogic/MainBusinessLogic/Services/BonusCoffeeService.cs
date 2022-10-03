using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.BonusCoffeeRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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

    public async Task<BonusCoffee> GetAsync(int id)
        => await _bonusCoffeeRepository.GetAsync(id);

    public async Task<string> CreateAsync(BonusCoffee bonusCoffee)
        => await _bonusCoffeeRepository.CreateAsync(bonusCoffee);

    public async Task<string> UpdateAsync(BonusCoffee bonusCoffee)
        => await _bonusCoffeeRepository.UpdateAsync(bonusCoffee);

    public async Task<string> DeleteAsync(BonusCoffee bonusCoffee)
        => await _bonusCoffeeRepository.DeleteAsync(bonusCoffee);
}