using AutoMapper;
using CoffeeShop.BusinessLogic.Common;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities.Identity;
using CoffeShop.Api.Controllers.Identity.Authorization;
using CoffeShop.Api.Controllers.Identity.Authorization.Policies;
using CoffeShop.Api.Dto.Input;
using CoffeShop.Api.ProxyExceptionHandlingLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Translation = CoffeShop.Api.Common.Translation;

namespace CoffeShop.Api.Controllers.Identity;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IProxyExceptionHandler<IUserService> _proxyExceptionHandler;
    private readonly IUserService _service;
    private readonly IMapper _mapper;
    public UserController(ILogger<UserController> logger, IUserService service,
        IProxyExceptionHandler<IUserService> proxyExceptionHandler,
        IMapper mapper)
    {
        _logger = logger;
        _service = service;
        _proxyExceptionHandler = proxyExceptionHandler;
        _mapper = mapper;
    }

    [Route("")]
    [HttpGet]
    [Permission(PoliciesNames.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAsync()
        => await _proxyExceptionHandler.ExecuteAsync(_service.GetAllAsync);

    [Route("{login}")]
    [HttpGet]
    [Permission(PoliciesNames.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAsync([FromRoute] string login)
        => await _proxyExceptionHandler.ExecuteAsync(_service.GetAsync, login);

    [Route("create")]
    [HttpPost]
    [Permission(PoliciesNames.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] UserDto user)
        => await _proxyExceptionHandler.ExecuteAsync(_service.CreateAsync, _mapper.Map<User>(user));

    [Route("update")]
    [HttpPut]
    [Permission(PoliciesNames.UserPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromBody] UserDto user)
        => await _proxyExceptionHandler.ExecuteAsync(_service.UpdateAsync, _mapper.Map<User>(user));
    
    [Route("delete")]
    [HttpDelete]
    [Permission(PoliciesNames.UserPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromBody] UserDto user)
        => await _proxyExceptionHandler.ExecuteAsync(_service.DeleteAsync, _mapper.Map<User>(user));
    
}
