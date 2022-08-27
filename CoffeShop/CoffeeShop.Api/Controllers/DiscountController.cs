using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers;
[ApiController]
public class DiscountController : ControllerBase
{
    private readonly ILogger<DiscountController> _logger;
    private readonly IDiscountService _service;
    public DiscountController(ILogger<DiscountController> logger,IDiscountService service)
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
    public async Task<IActionResult> CreateAsync([FromBody]Discount discount)
    {
        await _service.CreateAsync(discount);
        return Created(String.Empty,discount);
    }
    
    [Route("Update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody]Discount discount)
    {
        await _service.UpdateAsync(discount);
        return Ok();
    }
    
    [Route("Delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync([FromBody]Discount discount)
    {
        await _service.DeleteAsync(discount);
        return Ok();
    }
}