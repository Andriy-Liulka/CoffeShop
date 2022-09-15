using AutoMapper;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.dto.Authenticate;
using CoffeShop.Api.dto.Authenticate;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.Identity;

[ApiController]
[Route("api/[controller]")]
public class AuthenticateController : ControllerBase
{
    private readonly ILogger<AuthenticateController> _logger;
    private readonly IUserService _service;
    private readonly IMapper _mapper;
    private readonly IAuthenticateService _authenticateService;

    public AuthenticateController(ILogger<AuthenticateController> logger, IUserService service, IMapper mapper,
        IAuthenticateService authenticateService)
    {
        _logger = logger;
        _service = service;
        _mapper = mapper;
        _authenticateService = authenticateService;
    }

    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login([FromBody] LoginModelUi? loginModelUi)
    {
        if (loginModelUi is null)
            return BadRequest("Parameters are empty");
        return Ok(await _authenticateService.Login(_mapper.Map<LoginModel>(loginModelUi)));
    }

    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterModelUi? registerModelUi)
    {
        if (registerModelUi is null)
            return BadRequest("Parameters are empty");
        return Ok(await _authenticateService.Register(_mapper.Map<RegisterModel>(registerModelUi)));
    }

    [HttpPost]
    [Route("/refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenModelUi? tokenModelUi)
    {
        if (tokenModelUi is null)
            return BadRequest("Parameters are empty");
        return Ok(await _authenticateService.RefreshToken(_mapper.Map<TokenModel>(tokenModelUi)));
    }
}