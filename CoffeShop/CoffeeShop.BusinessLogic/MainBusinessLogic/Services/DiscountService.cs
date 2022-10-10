using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class DiscountService : IDiscountService
{
    private readonly IDiscountRepository _discountRepository;
    private readonly MainValidator _validator;
    public DiscountService(IDiscountRepository discountRepository,MainValidator validator)
    {
        _discountRepository = discountRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<Discount>> GetAllAsync()
        => await _discountRepository.GetAllAsync();

    public async Task<Discount> GetAsync(int id)
        => await _discountRepository.GetAsync(id);

    public async Task<string> CreateAsync(Discount discount)
    {
        _validator.Validate<Discount, DiscountValidator>(discount);
        return await _discountRepository.CreateAsync(discount);
    }

    public async Task<string> UpdateAsync(Discount discount)
    {
        _validator.Validate<Discount, DiscountValidator>(discount);
        return await _discountRepository.UpdateAsync(discount);
    }

    public async Task<string> DeleteAsync(Discount discount)
    {
        _validator.Validate<Discount, DiscountValidator>(discount);
        return await _discountRepository.DeleteAsync(discount);
    }
}