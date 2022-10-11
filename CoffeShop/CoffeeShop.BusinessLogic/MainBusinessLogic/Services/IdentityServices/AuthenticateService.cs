using System.IdentityModel.Tokens.Jwt;
using CoffeeShop.BusinessLogic.Common;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.IdentityCredentialRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.RoleRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;
using CoffeeShop.Domain.Constants;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;

public class AuthenticateService : IAuthenticateService
{
    private readonly IIdentityCredentialRepository _identityCredentialRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly TokenGenerator _tokenGenerator;
    private readonly HashGenerator _hashGenerator;
    private readonly IUserRepository _userRepository;
    private readonly MainValidator _validator;

    public AuthenticateService(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IIdentityCredentialRepository identityCredentialRepository,
        TokenGenerator tokenGenerator,
        HashGenerator hashGenerator,
        MainValidator validator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
        _roleRepository = roleRepository;
        _identityCredentialRepository = identityCredentialRepository;
        _hashGenerator = hashGenerator;
        _validator = validator;
    }

    public async Task<object> Login(LoginModel model)
    {
        _validator.Validate<LoginModel, LoginModelValidator>(model);
        var user = await _userRepository.GetFullAsync(model.Username);
        if (user is null || !user.PasswordHash.Equals(_hashGenerator.GenerateHash(model.Password 
            ?? throw new ArgumentNullException())))
            return new {ErrorMessage = "User credentials were failed!"};
        
        var tokenModel = _tokenGenerator.JwtAccessToken(new UserClaimDto
        {
            Email = user.Email,
            Name = user.Login,
            Role = user.Role?.Name
        });
        var refreshTokenModel = _tokenGenerator.RefreshToken();
        var accessToken = tokenModel.token;
        var validTo = tokenModel.ValidTo;

        user.IdentityCredential?.UpdateWith(() => new IdentityCredential
        {
            RefreshToken = refreshTokenModel.RefreshToken,
            ValidTo = refreshTokenModel.ValidTo
        });

        await _identityCredentialRepository.UpdateAsync(user.IdentityCredential);

        return new
        {
            RefreshToken = refreshTokenModel.RefreshToken,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
            ValidTo = validTo
        };
    }

    public async Task<object> Register(RegisterModel model)
    {
        _validator.Validate<RegisterModel, RegisterModelValidator>(model);
        var user = await _userRepository.GetAsync(model.Login);
        if (user is not null)
            return new {ErrorMessage = "Such user exist"};
        
        await _userRepository.CreateAsync(new User
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PasswordHash = _hashGenerator.GenerateHash(model.Password),
            IdentityCredentialLogin = model.Login,
            IdentityCredential = new IdentityCredential(),
            Role = await _roleRepository.GetAsync(Roles.Customer)
        });

        return new
        {
            Status = "Success",
            Message = "User created successfully!"
        };
    }

    public async Task<object> RefreshToken(TokenModel model)
    {
        var userData = _tokenGenerator.DecryptAccessToken(model.AccessToken);

        var user = await _userRepository.GetFullAsync(userData.Name);

        if (user is null ||
            user.IdentityCredential?.RefreshToken != model.RefreshToken ||
            user.IdentityCredential.ValidTo < DateTime.Now)
            return new {ErrorMessage = "Incorrect refresh or access token !"};
        
        var newAccessToken = _tokenGenerator.JwtAccessToken(userData);

        var newRefreshTokenModel = _tokenGenerator.RefreshToken();

        user.IdentityCredential?.UpdateWith(() => new IdentityCredential
        {
            RefreshToken = newRefreshTokenModel.RefreshToken,
            ValidTo = newRefreshTokenModel.ValidTo
        });

        await _identityCredentialRepository.UpdateAsync(user.IdentityCredential);

        return new
        {
            RefreshToken = newRefreshTokenModel.RefreshToken,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken.token),
            ValidTo = newAccessToken.ValidTo
        };
    }
}