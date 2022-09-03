using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class DiscountService : IDiscountService
{
    private readonly IRepository<Discount> _repository;
    private readonly IDiscountRepository _discountRepository;

    public DiscountService(IRepository<Discount> repository,IDiscountRepository discountRepository)
    {
        _repository = repository;
        _discountRepository = discountRepository;
    }

    public async Task<IEnumerable<Discount>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<Discount?> GetAsync(int id)
        => await _discountRepository.GetAsync(id);
    public async Task CreateAsync(Discount discount)
        => await _repository.CreateAsync(discount);

    public async Task UpdateAsync(Discount discount)
        => await _repository.UpdateAsync(discount);

    public async Task DeleteAsync(Discount discount)
        => await _repository.DeleteAsync(discount);
}