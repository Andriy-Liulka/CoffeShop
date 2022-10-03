using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountCoffeeRepositories;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;

public class DiscountCoffeeService : IDiscountCoffeeService
{
    private readonly IDiscountCoffeeRepository _discountCoffeeRepository;

    public DiscountCoffeeService(IDiscountCoffeeRepository discountCoffeeRepository)
    {
        _discountCoffeeRepository = discountCoffeeRepository;
    }

    public async Task<IEnumerable<DiscountCoffee>> GetAllAsync()
        => await _discountCoffeeRepository.GetAllAsync();

    public async Task<DiscountCoffee> GetAsync( int coffeeId, int discountId)
        => await _discountCoffeeRepository.GetAsync(coffeeId, discountId);

    public async Task<string> CreateAsync(DiscountCoffee discountCoffee)
        => await _discountCoffeeRepository.CreateAsync(discountCoffee);

    public async Task<string> UpdateAsync(DiscountCoffee discountCoffee)
        => await _discountCoffeeRepository.UpdateAsync(discountCoffee);

    public async Task<string> DeleteAsync(DiscountCoffee discountCoffee)
        => await _discountCoffeeRepository.DeleteAsync(discountCoffee);
}