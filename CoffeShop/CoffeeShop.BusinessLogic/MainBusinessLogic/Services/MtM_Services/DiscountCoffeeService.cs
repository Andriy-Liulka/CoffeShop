using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountCoffeeRepositories;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;

public class DiscountCoffeeService : IDiscountCoffeeService
{
    private readonly IDiscountCoffeeRepository _discountCoffeeRepository;
    private readonly IMainValidator _validator;

    public DiscountCoffeeService(IDiscountCoffeeRepository discountCoffeeRepository, IMainValidator validator)
    {
        _discountCoffeeRepository = discountCoffeeRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<DiscountCoffee>> GetAllAsync()
        => await _discountCoffeeRepository.GetAllAsync();

    public async Task<DiscountCoffee> GetAsync( int coffeeId, int discountId)
        => await _discountCoffeeRepository.GetAsync(coffeeId, discountId);

    public async Task<string> CreateAsync(DiscountCoffee discountCoffee)
    {
        _validator.Validate<DiscountCoffee, DiscountCoffeeValidator>(discountCoffee);
        return await _discountCoffeeRepository.CreateAsync(discountCoffee);
    }

    public async Task<string> UpdateAsync(DiscountCoffee discountCoffee)
    {
        _validator.Validate<DiscountCoffee, DiscountCoffeeValidator>(discountCoffee);
        return await _discountCoffeeRepository.UpdateAsync(discountCoffee);
    }

    public async Task<string> DeleteAsync(DiscountCoffee discountCoffee)
    {
        _validator.Validate<DiscountCoffee, DiscountCoffeeValidator>(discountCoffee);
        return await _discountCoffeeRepository.DeleteAsync(discountCoffee);
    }
}