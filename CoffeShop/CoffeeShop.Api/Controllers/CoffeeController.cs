using CoffeeShop.BusinessLogic.MainBusinessLogic;
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
    public async Task<IActionResult> GetAll()
    {
        var data =await _service.GetAll();
        return Ok(data);
    }
}