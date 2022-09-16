using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities;
using CoffeShop.Api.ProxyExceptionHandlingLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CoffeeController : ControllerBase
{
    private readonly ILogger<CoffeeController> _logger;
    private readonly IProxyExceptionHandler<ICoffeeService> _proxyExceptionHandler;
    private readonly ICoffeeService _service;

    public CoffeeController(ILogger<CoffeeController> logger,
        IProxyExceptionHandler<ICoffeeService> proxyExceptionHandler, ICoffeeService service)
    {
        _logger = logger;
        _proxyExceptionHandler = proxyExceptionHandler;
        _service = service;
    }

    [Route("")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
        => await _proxyExceptionHandler.ExecuteAsync(_service.GetAllAsync);

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
        => await _proxyExceptionHandler.ExecuteAsync(_service.GetAsync, id);

    [Route("create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] Coffee coffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.CreateAsync, coffee);

    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody] Coffee coffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.UpdateAsync, coffee);

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync([FromBody] Coffee coffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.DeleteAsync, coffee);
}