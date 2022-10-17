using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.BonusCoffeeRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class BonusCoffeeService : IBonusCoffeeService
{
    private readonly IBonusCoffeeRepository _bonusCoffeeRepository;
    private readonly IMainValidator _validator;

    public BonusCoffeeService(IBonusCoffeeRepository bonusCoffeeRepository, IMainValidator validator)
    {
        _bonusCoffeeRepository = bonusCoffeeRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<BonusCoffee>> GetAllAsync()
        =>await _bonusCoffeeRepository.GetAllAsync();
    
    public async Task<BonusCoffee> GetAsync(int id)
        => await _bonusCoffeeRepository.GetAsync(id);

    public async Task<string> CreateAsync(BonusCoffee bonusCoffee)
    {
        _validator.Validate<BonusCoffee, BonusCoffeeValidator>(bonusCoffee);
        return await _bonusCoffeeRepository.CreateAsync(bonusCoffee);
    }

    public async Task<string> UpdateAsync(BonusCoffee bonusCoffee)
    {
        _validator.Validate<BonusCoffee, BonusCoffeeValidator>(bonusCoffee);
        return await _bonusCoffeeRepository.UpdateAsync(bonusCoffee);
    }

    public async Task<string> DeleteAsync(BonusCoffee bonusCoffee)
    {
        _validator.Validate<BonusCoffee, BonusCoffeeValidator>(bonusCoffee);
        return await _bonusCoffeeRepository.DeleteAsync(bonusCoffee);
    }
}