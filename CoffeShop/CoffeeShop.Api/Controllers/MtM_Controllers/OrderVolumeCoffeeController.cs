using AutoMapper;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using CoffeShop.Api.dto.Ui;
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
    private readonly IMapper _mapper;

    public OrderVolumeCoffeeController(IOrderVolumeCoffeeService service,
        IProxyExceptionHandler<IOrderVolumeCoffeeService> proxyExceptionHandler, IMapper mapper)
    {
        _proxyExceptionHandler = proxyExceptionHandler;
        _service = service;
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
    public async Task<IActionResult> CreateAsync([FromBody] OrderVolumeCoffeeDto orderVolumeCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.CreateAsync, _mapper.Map<OrderVolumeCoffee>(orderVolumeCoffee));

    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromBody] OrderVolumeCoffeeDto orderVolumeCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.UpdateAsync, _mapper.Map<OrderVolumeCoffee>(orderVolumeCoffee));

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromBody] OrderVolumeCoffeeDto orderVolumeCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.DeleteAsync, _mapper.Map<OrderVolumeCoffee>(orderVolumeCoffee));
}
