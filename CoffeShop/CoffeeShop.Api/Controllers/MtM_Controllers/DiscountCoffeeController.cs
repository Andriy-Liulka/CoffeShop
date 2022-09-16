using AutoMapper;
using CoffeeShop.BusinessLogic.Dto;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using CoffeShop.Api.Dto;
using CoffeShop.Api.ProxyExceptionHandlingLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.MtM_Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DiscountCoffeeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IProxyExceptionHandler<IDiscountService> _proxyExceptionHandler;
    private readonly IDiscountCoffeeService _service;

    public DiscountCoffeeController(
        IDiscountCoffeeService service,
        IMapper mapper,
        IProxyExceptionHandler<IDiscountService> proxyExceptionHandler)
    {
        _proxyExceptionHandler = proxyExceptionHandler;
        _service = service;
        _mapper = mapper;
    }

    [Route("")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
        => await _proxyExceptionHandler.ExecuteAsync(_service.GetAllAsync);

    [Route("{coffeeId}/{discountId}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute] DiscountCoffeeGetAsyncDtoUi key)
        => await _proxyExceptionHandler.ExecuteAsync(
            _service.GetAsync,
            _mapper.Map<DiscountCoffeeGetAsyncDto>(key));

    [Route("create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] DiscountCoffee discountCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.CreateAsync, discountCoffee);

    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody] DiscountCoffee discountCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.UpdateAsync, discountCoffee);

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync([FromBody] DiscountCoffee discountCoffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.DeleteAsync, discountCoffee);
}
