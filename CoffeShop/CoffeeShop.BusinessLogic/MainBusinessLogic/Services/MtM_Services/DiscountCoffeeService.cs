using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountCoffeeRepositories;
using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;

public class DiscountCoffeeService : IDiscountCoffeeService
{
    private readonly IRepository<DiscountCoffee> _repository;
    private readonly IDiscountCoffeeRepository _discountCoffeeRepository;

    public DiscountCoffeeService(IRepository<DiscountCoffee> repository,IDiscountCoffeeRepository discountCoffeeRepository)
    {
        _repository = repository;
        _discountCoffeeRepository = discountCoffeeRepository;
    }

    public async Task<IEnumerable<DiscountCoffee>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<DiscountCoffee?> GetAsync(int discountId,int coffeetId)
        => await _discountCoffeeRepository.GetAsync(discountId,coffeetId);

    public async Task CreateAsync(DiscountCoffee discountCoffee)
        => await _repository.CreateAsync(discountCoffee);
    public async Task UpdateAsync(DiscountCoffee discountCoffee)
        => await _repository.UpdateAsync(discountCoffee);

    public async Task DeleteAsync(DiscountCoffee discountCoffee)
        => await _repository.DeleteAsync(discountCoffee);
}