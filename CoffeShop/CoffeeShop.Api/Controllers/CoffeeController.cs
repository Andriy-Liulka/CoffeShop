using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers;

[ApiController]
public class CoffeeController : ControllerBase
{
    private readonly ILogger<CoffeeController> _logger;

    public CoffeeController(ILogger<CoffeeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    //[Rou]
    public IActionResult Get([FromRoute]string id)
    {
        return Ok();
    }
}