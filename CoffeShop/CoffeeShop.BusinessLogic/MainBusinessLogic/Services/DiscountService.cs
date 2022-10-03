using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class DiscountService : IDiscountService
{
    private readonly IDiscountRepository _discountRepository;

    public DiscountService(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public async Task<IEnumerable<Discount>> GetAllAsync()
        => await _discountRepository.GetAllAsync();

    public async Task<Discount> GetAsync(int id)
        => await _discountRepository.GetAsync(id);

    public async Task<string> CreateAsync(Discount discount)
        => await _discountRepository.CreateAsync(discount);

    public async Task<string> UpdateAsync(Discount discount)
        => await _discountRepository.UpdateAsync(discount);

    public async Task<string> DeleteAsync(Discount discount)
        =>await _discountRepository.DeleteAsync(discount);
}