using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BonusCoffeeController : ControllerBase
{
    private readonly ILogger<BonusCoffeeController> _logger;
    private readonly IBonusCoffeeService _service;
    public BonusCoffeeController(ILogger<BonusCoffeeController> logger,IBonusCoffeeService service)
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
    public async Task<IActionResult> GetAsync([FromRoute]int id) 
        => Ok(await _service.GetAsync(id));

    [Route("create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody]BonusCoffee bonusCoffee)
    {
        await _service.CreateAsync(bonusCoffee);
        return Created(String.Empty,bonusCoffee);
    }
    
    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody]BonusCoffee bonusCoffee)
    {
        await _service.UpdateAsync(bonusCoffee);
        return Ok();
    }
    
    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync([FromBody]BonusCoffee bonusCoffee)
    {
        await _service.DeleteAsync(bonusCoffee);
        return Ok();
    }
}
