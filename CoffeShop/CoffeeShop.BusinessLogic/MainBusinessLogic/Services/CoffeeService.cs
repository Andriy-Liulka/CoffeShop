using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;


public class CoffeeService : ICoffeeService
{
    private readonly ICoffeeRepository _coffeeRepository;
    public CoffeeService(ICoffeeRepository coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }

    public async Task<IEnumerable<Coffee>> GetAllAsync() 
        => await _coffeeRepository.GetAllAsync();
    
    public async Task<Coffee?> GetAsync(int id)
        => await _coffeeRepository.GetAsync(id);

    public async Task CreateAsync(Coffee coffee)
        => await _coffeeRepository.CreateAsync(coffee);

    public async Task UpdateAsync(Coffee coffee)
        => await _coffeeRepository.UpdateAsync(coffee);
    
    public async Task DeleteAsync(Coffee coffee)
        => await _coffeeRepository.DeleteAsync(coffee);
}
