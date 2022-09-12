using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace CoffeShop.Api.Security;

public class TokenGenerator
{
    private readonly IConfiguration _configuration;
    public TokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    internal JwtSecurityToken JwtAccessToken()
    {
        return null;
    }
    
    internal string  RefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return string.Concat(Guid.NewGuid().ToString(),Convert.ToBase64String(randomNumber));
    }
}