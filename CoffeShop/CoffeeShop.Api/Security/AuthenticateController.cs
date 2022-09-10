using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure;
using CoffeShop.Api.dto;
using CoffeShop.Api.Security.AuthModels;
using CoffeShop.Api.Security.AuthModels.CommonModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CoffeShop.Api.Security;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly UserManager<ApplicationSecurityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly TokensGenerator _tokensGenerator;

    internal AuthenticateController(
        UserManager<ApplicationSecurityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        TokensGenerator tokensGenerator)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _tokensGenerator = tokensGenerator;
        
        if (! _roleManager.RoleExistsAsync("User").Result)
             _roleManager.CreateAsync(new IdentityRole("User"));
        if (! _roleManager.RoleExistsAsync("Admin").Result)
             _roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        var user = await _userManager.FindByNameAsync(loginModel.Username);

        if (user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
            return Unauthorized();

        var userRoles = await _userManager.GetRolesAsync(user);

        var accessToken = _tokensGenerator.CreateToken(new UserClaimsDto
        {
            Role = userRoles.FirstOrDefault(),
            Username = loginModel.Username,
        });
        var refreshToken = _tokensGenerator.GenerateRefreshToken();
        
        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
        
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

        await _userManager.UpdateAsync(user);

        return Ok(new
        {
            Token = new JwtSecurityTokenHandler().WriteToken(accessToken),
            RefreshToken = refreshToken,
            Expiration = accessToken.ValidTo
        });
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel
            {
                Status = StatusCodes.Status500InternalServerError.ToString(),
                Message ="User with such username already exist !" 
            });
        
        ApplicationSecurityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        
        var result = await _userManager.CreateAsync(user, model.Password);
        
        if(!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel
            {
                Status = "Error", 
                Message = "User creation failed! Please check user details and try again."
            });
        
        return Ok(new ResponseModel
        {
            Status = "Success",
            Message = "User created successfully!"
        });
    }
    
    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel
            {
                Status = "Error", 
                Message = "User already exists!"
            });

        ApplicationSecurityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel
            {
                Status = "Error", 
                Message = "User creation failed! Please check user details and try again."
            });
        
        await _userManager.AddToRoleAsync(user, "Admin");


        await _userManager.AddToRoleAsync(user, "User");

        return Ok(new ResponseModel
        {
            Status = "Success", 
            Message = "User created successfully!"
        });
    }
    
    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || 
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase)
            )
            throw new SecurityTokenException("Invalid token");

        return principal;

    }
    
    [HttpPost]
    [Route("refresh-token")]
    public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
    {
        if (tokenModel is null)
        {
            return BadRequest("Invalid client request");
        }

        string? accessToken = tokenModel.AccessToken;
        string? refreshToken = tokenModel.RefreshToken;

        var principal = GetPrincipalFromExpiredToken(accessToken);
        if (principal == null)
        {
            return BadRequest("Invalid access token or refresh token");
        }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        string username = principal.Identity.Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        var user = await _userManager.FindByNameAsync(username);

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return BadRequest("Invalid access token or refresh token");
        }

        var newAccessToken = _tokensGenerator.CreateTokenForClaims(principal.Claims.ToList());
        var newRefreshToken = _tokensGenerator.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await _userManager.UpdateAsync(user);

        return new ObjectResult(new
        {
            accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            refreshToken = newRefreshToken
        });
    }
}