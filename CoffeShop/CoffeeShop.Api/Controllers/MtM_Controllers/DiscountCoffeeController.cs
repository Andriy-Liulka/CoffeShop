using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.MtM_Controllers;
[ApiController]
[Route("api/[controller]")]
public class DiscountCoffeeController  : ControllerBase
{
    private readonly ILogger<DiscountCoffeeController> _logger;
    private readonly IDiscountCoffeeService _service;
    public DiscountCoffeeController(ILogger<DiscountCoffeeController> logger,IDiscountCoffeeService service)
    {
        _logger = logger;
        _service = service;
    }
    [Route("")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync() 
        => Ok(await _service.GetAllAsync());

    [Route("{coffeeId}/{discountId}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute]int coffeeId,[FromRoute]int discountId) 
        => Ok(await _service.GetAsync(coffeeId,discountId));

    [Route("create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody]DiscountCoffee discountCoffee)
    {
        await _service.CreateAsync(discountCoffee);
        return Created(String.Empty,discountCoffee);
    }
    
    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody]DiscountCoffee discountCoffee)
    {
        await _service.UpdateAsync(discountCoffee);
        return Ok();
    }
    
    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync([FromBody]DiscountCoffee discountCoffee)
    {
        await _service.DeleteAsync(discountCoffee);
        return Ok();
    }
}
