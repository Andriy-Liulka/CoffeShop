using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Constants;
using CoffeShop.Api.ProxyExceptionHandlingLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.Identity;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles=Roles.Admin)]
public class RoleController : ControllerBase
{
    private readonly IRoleService _service;
    private readonly IProxyExceptionHandler<IRoleService> _proxyExceptionHandler;

    public RoleController(IRoleService service, IProxyExceptionHandler<IRoleService> proxyExceptionHandler)
    {
        _service = service;
        _proxyExceptionHandler = proxyExceptionHandler;
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
        => await _proxyExceptionHandler.ExecuteAsync(_service.GetAllAsync);

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute] string name)
        => await _proxyExceptionHandler.ExecuteAsync(_service.GetAsync, name);
}
