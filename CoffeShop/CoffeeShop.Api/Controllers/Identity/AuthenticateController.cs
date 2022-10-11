using AutoMapper;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;
using CoffeShop.Api.Dto.Authenticate;
using CoffeShop.Api.ProxyExceptionHandlingLayer;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers.Identity;

[ApiController]
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
    public async Task<IActionResult> Login([FromBody] LoginModelDto? loginModelDto)
        => await _proxyExceptionHandler.ExecuteAsync(
            _authenticateService.Login,
            _mapper.Map<LoginModel>(loginModelDto));

    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterModelDto? registerModelDto)
        => await _proxyExceptionHandler.ExecuteAsync(
            _authenticateService.Register,
            _mapper.Map<RegisterModel>(registerModelDto));

    [HttpPost]
    [Route("/refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenModelDto? tokenModelDto)
        => await _proxyExceptionHandler.ExecuteAsync(
            _authenticateService.RefreshToken,
            _mapper.Map<TokenModel>(tokenModelDto));
}