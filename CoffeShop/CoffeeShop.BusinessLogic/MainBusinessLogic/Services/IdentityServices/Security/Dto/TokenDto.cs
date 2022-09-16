using System.IdentityModel.Tokens.Jwt;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto;

public class TokenDto
{
    public JwtSecurityToken token { get; set; }
    public DateTime ValidTo { get; set; }
}