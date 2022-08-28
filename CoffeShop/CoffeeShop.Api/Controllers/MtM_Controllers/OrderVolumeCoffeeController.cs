using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.MtM_Controllers;

[ApiController]
public class OrderVolumeCoffeeController : ControllerBase
{
    private readonly ILogger<OrderVolumeCoffeeController> _logger;
    private readonly IOrderVolumeCoffeeService _service;
    public OrderVolumeCoffeeController(ILogger<OrderVolumeCoffeeController> logger,IOrderVolumeCoffeeService service)
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
    public async Task<IActionResult> GetAsync([FromRoute]int orderId,[FromRoute]int volumeId,[FromRoute]int coffeeId) 
        => Ok(await _service.GetAsync(orderId, volumeId, coffeeId));

    [Route("create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody]OrderVolumeCoffee orderVolumeCoffee)
    {
        await _service.CreateAsync(orderVolumeCoffee);
        return Created(String.Empty,orderVolumeCoffee);
    }
    
    [Route("Update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody]OrderVolumeCoffee orderVolumeCoffee)
    {
        await _service.UpdateAsync(orderVolumeCoffee);
        return Ok();
    }
    
    [Route("Delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync([FromBody]OrderVolumeCoffee orderVolumeCoffee)
    {
        await _service.DeleteAsync(orderVolumeCoffee);
        return Ok();
    }
}