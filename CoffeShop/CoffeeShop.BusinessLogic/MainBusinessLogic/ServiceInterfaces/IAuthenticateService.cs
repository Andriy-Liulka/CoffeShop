﻿using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.dto.Authenticate;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IAuthenticateService
{
    Task<object> Login(LoginModel model);
    Task<object> Register(RegisterModel model);
    Task<object> RefreshToken(TokenModel model);
}