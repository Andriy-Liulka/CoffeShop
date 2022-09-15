using System.IdentityModel.Tokens.Jwt;
using CoffeeShop.BusinessLogic.Common;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.dto.Authenticate;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.RoleRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;
using CoffeeShop.Domain.Constants;
using CoffeeShop.Domain.Entities.Identity;
using CoffeShop.Api.dto;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;

public class AuthenticateService : IAuthenticateService
{
    private readonly IUserRepository _userRepository;
    private readonly IRepository<IdentityCredential> _authenticateRepository;
    private readonly IRepository<User> _userBaseRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly TokenGenerator _tokenGenerator;
    
    public AuthenticateService(
        IRepository<IdentityCredential> authenticateRepository,
        IRepository<User> userBaseRepository,
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        TokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _authenticateRepository = authenticateRepository;
        _tokenGenerator = tokenGenerator;
        _userBaseRepository = userBaseRepository;
        _roleRepository = roleRepository;
    }

    public async Task<object> Login(LoginModel model)
    {
        var user = await _userRepository.GetFullAsync(model.Username);
        if (user is null || !user.PasswordHash.Equals(model.Password))
            return new { Message = "User credentials were failed!" };
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

        await _authenticateRepository.UpdateAsync(user.IdentityCredential);
        
        return new
        {
            RefreshToken = refreshTokenModel.RefreshToken,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
            ValidTo = validTo
        };
    }
    
    public async Task<object> Register(RegisterModel model)
    {
        var user = await _userRepository.GetAsync(model.Login);
        if (user is not null)
            return new {Message="Such user exist"};

        await _userBaseRepository.CreateAsync(new User
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PasswordHash = model.Password,
            IdentityCredentialLogin = model.Login,
            IdentityCredential = new IdentityCredential(),
            Role = await _roleRepository.GetAsync(Roles.Customer)
        });

        return new { Status = "Success", Message = "User created successfully!" };
    }

    public async Task<object> RefreshToken(TokenModel model)
    {
        var userData = _tokenGenerator.DecryptAccessToken(model.AccessToken);

        var user = await _userRepository.GetFullAsync(userData.Name);

        if (user is null || 
            user.IdentityCredential?.RefreshToken != model.RefreshToken || 
            user.IdentityCredential.ValidTo < DateTime.Now )
            return new { Message = "Incorrect refresh or access token !" };
        
        var newAccessToken = _tokenGenerator.JwtAccessToken(userData);

        var newRefreshTokenModel = _tokenGenerator.RefreshToken();
        
        user.IdentityCredential?.UpdateWith(() => new IdentityCredential
        {
            RefreshToken = newRefreshTokenModel.RefreshToken,
            ValidTo = newRefreshTokenModel.ValidTo
        });

        await _authenticateRepository.UpdateAsync(user.IdentityCredential);
        
        return new
        {
            RefreshToken = newRefreshTokenModel.RefreshToken,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken.token),
            ValidTo = newAccessToken.ValidTo
        };
    }
}