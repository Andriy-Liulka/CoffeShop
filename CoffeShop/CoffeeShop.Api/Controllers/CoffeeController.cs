using CoffeeShop.BusinessLogic.MainBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers;

[ApiController]
public class CoffeeController : ControllerBase
{
    private readonly ILogger<CoffeeController> _logger;
    private readonly ICoffeeBusinessLogic _businessLogic;
    public CoffeeController(ILogger<CoffeeController> logger,ICoffeeBusinessLogic businessLogic)
    {
        _logger = logger;
        _businessLogic = businessLogic;
    }
    [Route("")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data =await _businessLogic.GetAll();
        return Ok(data);
    }
}