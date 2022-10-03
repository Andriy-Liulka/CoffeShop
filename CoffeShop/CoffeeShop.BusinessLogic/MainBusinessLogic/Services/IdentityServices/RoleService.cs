﻿using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.RoleRepositories;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
        => await _roleRepository.GetAllAsync();

    public async Task<Role> GetAsync(string name)
        => await _roleRepository.GetAsync(name); 
}