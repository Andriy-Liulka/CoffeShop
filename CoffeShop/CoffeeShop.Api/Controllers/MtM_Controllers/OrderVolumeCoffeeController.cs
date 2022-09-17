using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using CoffeShop.Api.ProxyExceptionHandlingLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.MtM_Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrderVolumeCoffeeController : ControllerBase
{
    private readonly IProxyExceptionHandler<IOrderVolumeCoffeeService> _proxyExceptionHandler;
    private readonly IOrderVolumeCoffeeService _service;

    public OrderVolumeCoffeeController(IOrderVolumeCoffeeService service,
        IProxyExceptionHandler<IOrderVolumeCoffeeService> proxyExceptionHandler)
    {
        _proxyExceptionHandler = proxyExceptionHandler;
        _service = service;
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
    public async Task<IActionResult> CreateAsync([FromBody] OrderVolumeCoffee orderVolumeCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.CreateAsync, orderVolumeCoffee);

    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromBody] OrderVolumeCoffee orderVolumeCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.UpdateAsync, orderVolumeCoffee);

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromBody] OrderVolumeCoffee orderVolumeCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.DeleteAsync,orderVolumeCoffee);
}
