using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.dto.Authenticate;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IAuthenticateService
{
    Task<IActionResult> Login(LoginModel model);
    Task<IActionResult> Register(RegisterModel model);
    Task<IActionResult> RefreshToken(TokenModel model);
}