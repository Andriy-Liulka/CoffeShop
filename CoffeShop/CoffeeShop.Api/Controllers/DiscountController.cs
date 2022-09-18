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
public class DiscountController : ControllerBase
{
    private readonly IProxyExceptionHandler<IDiscountService> _proxyExceptionHandler;
    private readonly IDiscountService _service;
    private readonly IMapper _mapper;

    public DiscountController(IDiscountService service, IProxyExceptionHandler<IDiscountService> proxyExceptionHandler, IMapper mapper)
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
    public async Task<IActionResult> CreateAsync([FromBody] DiscountUi discount)
        => await _proxyExceptionHandler.ExecuteAsync(_service.CreateAsync, _mapper.Map<Discount>(discount));

    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromBody] DiscountUi discount)
        => await _proxyExceptionHandler.ExecuteAsync(_service.UpdateAsync, _mapper.Map<Discount>(discount));

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromBody] DiscountUi discount)
        => await _proxyExceptionHandler.ExecuteAsync(_service.DeleteAsync, _mapper.Map<Discount>(discount));
}
