using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.Domain.Constants;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.Identity;
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles=Roles.Admin)]
public class UserController : ControllerBase
{ 
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _service;
    public UserController(ILogger<UserController> logger,IUserService service)
    {
        _logger = logger;
        _service = service;
    }
    [Route("")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync() 
        => Ok(await _service.GetAllAsync());

    [Route("{login}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute]string login) 
        => Ok(await _service.GetAsync(login));

    [Route("create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody]User user)
    {
        await _service.CreateAsync(user);
        return Created(String.Empty,user);
    }
    
    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody]User user)
    {
        await _service.UpdateAsync(user);
        return Ok();
    }
    
    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync([FromBody]User user)
    {
        await _service.DeleteAsync(user);
        return Ok();
    }
}
