using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.Identity;

[ApiController]
public class RoleController  : ControllerBase
{
    private readonly ILogger<RoleController> _logger;
    private readonly IRoleService _service;
    public RoleController(ILogger<RoleController> logger,IRoleService service)
    {
        _logger = logger;
        _service = service;
    }
    [Route("")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync() 
        => Ok(await _service.GetAllAsync());

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute]int userId) 
        => Ok(await _service.GetAsync(userId));
}