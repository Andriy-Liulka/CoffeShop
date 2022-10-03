using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IAuthenticateService
{
    Task<object> Login(LoginModel model);
    Task<object> Register(RegisterModel model);
    Task<object> RefreshToken(TokenModel model);
}