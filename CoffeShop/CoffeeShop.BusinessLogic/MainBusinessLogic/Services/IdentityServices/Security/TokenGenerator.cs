using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CoffeShop.Api.dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security;

public class TokenGenerator
{
    private readonly IConfiguration _configuration;
    public TokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    internal TokenDto JwtAccessToken(UserClaimDto model)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? throw new NullReferenceException()));
        _ = int.TryParse(_configuration["JWT:AccessTokenValidityInMinutes"], out int tokenValidInMinutes);
        return new TokenDto
        {
            ValidTo = DateTime.Now.AddMinutes(tokenValidInMinutes),
            token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(tokenValidInMinutes),
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims:new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role,model.Role),
                    new Claim(ClaimTypes.Email,model.Email),
                    new Claim(ClaimTypes.Name,model.Name)
                },
                signingCredentials:new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256)
            )
        };
    }
    
    internal RefreshTokenDto  RefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return new RefreshTokenDto
        {
            RefreshToken = string.Concat(Guid.NewGuid().ToString(),Convert.ToBase64String(randomNumber)),
            ValidTo = DateTime.Now.AddDays(Double.Parse(_configuration["JWT:RefreshTokenValidityInDays"]))
        };
    }
    
    internal UserClaimDto  DecryptAccessToken(string token)
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
        
        if (securityToken is not JwtSecurityToken jwtSecurityToken 
            || 
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return new UserClaimDto
        {
            Role = principal?.Claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value ?? throw new NullReferenceException(),
            Name = principal?.Claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name))?.Value ?? throw new NullReferenceException(),
            Email = principal?.Claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value ?? throw new NullReferenceException(),
        };
    }
}