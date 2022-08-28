using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VolumeController  : ControllerBase
{
    private readonly ILogger<VolumeController> _logger;
    private readonly IVolumeService _service;
    public VolumeController(ILogger<VolumeController> logger,IVolumeService service)
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
    public async Task<IActionResult> CreateAsync([FromBody]Volume volume)
    {
        await _service.CreateAsync(volume);
        return Created(String.Empty,volume);
    }
    
    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody]Volume volume)
    {
        await _service.UpdateAsync(volume);
        return Ok();
    }
    
    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync([FromBody]Volume volume)
    {
        await _service.DeleteAsync(volume);
        return Ok();
    }
}
