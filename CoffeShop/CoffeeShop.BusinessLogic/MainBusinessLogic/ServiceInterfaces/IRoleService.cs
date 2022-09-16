﻿using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IRoleService
{
    Task<IActionResult> GetAllAsync();
    Task<IActionResult> GetAsync(string name);
}