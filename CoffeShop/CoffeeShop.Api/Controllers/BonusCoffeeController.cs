using AutoMapper;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities;
using CoffeShop.Api.dto.Ui;
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
    private readonly IMapper _mapper;

    public BonusCoffeeController(IBonusCoffeeService service,
        IProxyExceptionHandler<IBonusCoffeeService> proxyExceptionHandler, IMapper mapper)
    {
        _service = service;
        _proxyExceptionHandler = proxyExceptionHandler;
        _mapper = mapper;
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
    public async Task<IActionResult> CreateAsync([FromBody] BonusCoffeeUi bonusCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.CreateAsync, _mapper.Map<BonusCoffee>(bonusCoffee));

    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromBody] BonusCoffeeUi bonusCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.UpdateAsync, _mapper.Map<BonusCoffee>(bonusCoffee));

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromBody] BonusCoffeeUi bonusCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.DeleteAsync, _mapper.Map<BonusCoffee>(bonusCoffee));
}
