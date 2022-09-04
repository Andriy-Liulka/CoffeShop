using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;


public class CoffeeService : ICoffeeService
{
    private readonly IRepository<Coffee> _repository;
    private readonly ICoffeeRepository _coffeeRepository;
    public CoffeeService(IRepository<Coffee> repository, ICoffeeRepository coffeeRepository)
    {
        _repository = repository;
        _coffeeRepository = coffeeRepository;
    }

    public async Task<IEnumerable<Coffee>> GetAllAsync() 
        => await _repository.GetAllAsync();
    
    public async Task<Coffee?> GetAsync(int id)
        => await _coffeeRepository.GetAsync(id);

    public async Task CreateAsync(Coffee coffee)
        => await _repository.CreateAsync(coffee);

    public async Task UpdateAsync(Coffee coffee)
        => await _repository.UpdateAsync(coffee);
    
    public async Task DeleteAsync(Coffee coffee)
        => await _repository.DeleteAsync(coffee);
}
