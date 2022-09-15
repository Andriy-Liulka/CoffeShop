using System.IdentityModel.Tokens.Jwt;

namespace CoffeShop.Api.dto;

public class TokenDto
{
    public JwtSecurityToken token { get; set; }
    public DateTime ValidTo { get; set; }
}