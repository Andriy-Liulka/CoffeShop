using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers;

[ApiController]
public class CoffeeController : ControllerBase
{
    private readonly ILogger<CoffeeController> _logger;
    private readonly ICoffeeService _service;
    public CoffeeController(ILogger<CoffeeController> logger,ICoffeeService service)
    {
        _logger = logger;
        _service = service;
    }
    [Route("")]
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute]int id) => Ok(await _service.Get(id));

}