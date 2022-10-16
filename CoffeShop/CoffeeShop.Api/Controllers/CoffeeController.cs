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
public class CoffeeController : ControllerBase
{
    private readonly ILogger<CoffeeController> _logger;
    private readonly IProxyExceptionHandler<ICoffeeService> _proxyExceptionHandler;
    private readonly ICoffeeService _service;
    private readonly IMapper _mapper;

    public CoffeeController(ILogger<CoffeeController> logger,
        IProxyExceptionHandler<ICoffeeService> proxyExceptionHandler, ICoffeeService service, IMapper mapper)
    {
        _logger = logger;
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
    public async Task<IActionResult> CreateAsync([FromBody] CoffeeDto coffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.CreateAsync, _mapper.Map<Coffee>(coffee));
    
    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromBody] CoffeeDto coffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.UpdateAsync, _mapper.Map<Coffee>(coffee));

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromBody] CoffeeDto coffee)
        => await _proxyExceptionHandler.ExecuteAsync(_service.DeleteAsync, _mapper.Map<Coffee>(coffee));
}