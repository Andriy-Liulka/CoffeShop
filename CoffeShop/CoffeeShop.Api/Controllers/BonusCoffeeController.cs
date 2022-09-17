﻿using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities;
using CoffeShop.Api.ProxyExceptionHandlingLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BonusCoffeeController : ControllerBase
{
    private readonly IProxyExceptionHandler<IBonusCoffeeService> _proxyExceptionHandler;
    private readonly IBonusCoffeeService _service;

    public BonusCoffeeController(IBonusCoffeeService service,
        IProxyExceptionHandler<IBonusCoffeeService> proxyExceptionHandler)
    {
        _service = service;
        _proxyExceptionHandler = proxyExceptionHandler;
    }

    [Route("")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAsync()
        => await _proxyExceptionHandler.ExecuteAsync(_service.GetAllAsync);

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
        => await _proxyExceptionHandler.ExecuteAsync(_service.GetAsync, id);

    [Route("create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] BonusCoffee bonusCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.CreateAsync, bonusCoffee);

    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromBody] BonusCoffee bonusCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.UpdateAsync, bonusCoffee);

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromBody] BonusCoffee bonusCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.DeleteAsync, bonusCoffee);
}
