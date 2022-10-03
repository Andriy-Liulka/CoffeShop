﻿using CoffeeShop.BusinessLogic.Common;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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


    public async Task<Coffee> GetAsync(int id)
        => await _coffeeRepository.GetAsync(id);

    public async Task<string> CreateAsync(Coffee coffee)
        => await _coffeeRepository.CreateAsync(coffee);


    public async Task<string> UpdateAsync(Coffee coffee)
        => await _coffeeRepository.UpdateAsync(coffee);
    

    public async Task<string> DeleteAsync(Coffee coffee)
        => await _coffeeRepository.DeleteAsync(coffee);
}