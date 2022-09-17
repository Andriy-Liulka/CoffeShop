using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities;
using CoffeShop.Api.ProxyExceptionHandlingLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VolumeController : ControllerBase
{
    private readonly IProxyExceptionHandler<IVolumeService> _proxyExceptionHandler;
    private readonly IVolumeService _service;

    public VolumeController(IVolumeService service, IProxyExceptionHandler<IVolumeService> proxyExceptionHandler)
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
    public async Task<IActionResult> CreateAsync([FromBody] Volume volume)
        => await _proxyExceptionHandler.ExecuteAsync(_service.CreateAsync, volume);

    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromBody] Volume volume)
        => await _proxyExceptionHandler.ExecuteAsync(_service.UpdateAsync, volume);

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromBody] Volume volume)
        => await _proxyExceptionHandler.ExecuteAsync(_service.DeleteAsync, volume);
}
