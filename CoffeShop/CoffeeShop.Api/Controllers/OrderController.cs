using AutoMapper;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities;
using CoffeShop.Api.Controllers.Identity.Authorization;
using CoffeShop.Api.Controllers.Identity.Authorization.Policies;
using CoffeShop.Api.Dto.Input;
using CoffeShop.Api.ProxyExceptionHandlingLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Permission(PoliciesNames.UserPolicy)]
public class OrderController : ControllerBase
{
    private readonly IProxyExceptionHandler<IDiscountService> _proxyExceptionHandler;
    private readonly IOrderService _service;
    private readonly IMapper _mapper;

    public OrderController(IOrderService service, IProxyExceptionHandler<IDiscountService> proxyExceptionHandler, IMapper mapper)
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
    public async Task<IActionResult> CreateAsync([FromBody] OrderDto order)
        => await _proxyExceptionHandler.ExecuteAsync(_service.CreateAsync, _mapper.Map<Order>(order));

    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromBody] OrderDto order)
        => await _proxyExceptionHandler.ExecuteAsync(_service.UpdateAsync, _mapper.Map<Order>(order));

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromBody] OrderDto order)
        => await _proxyExceptionHandler.ExecuteAsync(_service.DeleteAsync, _mapper.Map<Order>(order));
}
