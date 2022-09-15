using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.Identity;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles=Roles.Admin)]
public class RoleController  : ControllerBase
{
    private readonly ILogger<RoleController> _logger;
    private readonly IRoleService _service;
    public RoleController(ILogger<RoleController> logger,IRoleService service)
    {
        _logger = logger;
        _service = service;
    }
    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync() 
        => Ok(await _service.GetAllAsync());

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute]string name) 
        => Ok(await _service.GetAsync(name));
}
