using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.Identity;
[ApiController]
[Route("api/[controller]")]
public class AuthenticateController : ControllerBase
{
    private readonly ILogger<AuthenticateController> _logger;
    private readonly IUserService _service;
    public AuthenticateController(ILogger<AuthenticateController> logger,IUserService service)
    {
        _logger = logger;
        _service = service;
    }
    
    
}