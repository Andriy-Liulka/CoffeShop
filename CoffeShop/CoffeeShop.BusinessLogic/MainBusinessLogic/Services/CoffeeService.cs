using CoffeeShop.BusinessLogic.Common;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class CoffeeService : ICoffeeService
{
    private readonly ICoffeeRepository _coffeeRepository;
    private readonly IMainValidator _validator;
    public CoffeeService(ICoffeeRepository coffeeRepository, IMainValidator validator)
    {
        _coffeeRepository = coffeeRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<Coffee>> GetAllAsync()
        => await _coffeeRepository.GetAllAsync();


    public async Task<Coffee> GetAsync(int id)
        => await _coffeeRepository.GetAsync(id);

    public async Task<string> CreateAsync(Coffee coffee)
    {
        _validator.Validate<Coffee, CoffeeValidator>(coffee);
        return await _coffeeRepository.CreateAsync(coffee);
    }
    
    public async Task<string> UpdateAsync(Coffee coffee)
    {
        _validator.Validate<Coffee, CoffeeValidator>(coffee);
        return await _coffeeRepository.UpdateAsync(coffee);
    }

    public async Task<string> DeleteAsync(Coffee coffee)
    {
        _validator.Validate<Coffee, CoffeeValidator>(coffee);
        return await _coffeeRepository.DeleteAsync(coffee);
    }
}