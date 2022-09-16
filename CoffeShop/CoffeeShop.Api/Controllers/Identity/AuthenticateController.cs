using AutoMapper;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;
using CoffeShop.Api.Dto.Authenticate;
using CoffeShop.Api.ProxyExceptionHandlingLayer;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.Identity;

[ApiController]
[Route("api/[controller]")]
public class AuthenticateController : ControllerBase
{
    private readonly IAuthenticateService _authenticateService;
    private readonly IMapper _mapper;
    private readonly IProxyExceptionHandler<IAuthenticateService> _proxyExceptionHandler;
    private readonly IUserService _service;

    public AuthenticateController(
        IUserService service,
        IMapper mapper,
        IAuthenticateService authenticateService,
        IProxyExceptionHandler<IAuthenticateService> proxyExceptionHandler)
    {
        _service = service;
        _mapper = mapper;
        _authenticateService = authenticateService;
        _proxyExceptionHandler = proxyExceptionHandler;
    }

    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login([FromBody] LoginModelUi? loginModelUi)
        => await _proxyExceptionHandler.ExecuteAsync(
            _authenticateService.Login,
            _mapper.Map<LoginModel>(loginModelUi));

    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterModelUi? registerModelUi)
        => await _proxyExceptionHandler.ExecuteAsync(
            _authenticateService.Register,
            _mapper.Map<RegisterModel>(registerModelUi));

    [HttpPost]
    [Route("/refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenModelUi? tokenModelUi)
        => await _proxyExceptionHandler.ExecuteAsync(
            _authenticateService.RefreshToken,
            _mapper.Map<TokenModel>(tokenModelUi));
}