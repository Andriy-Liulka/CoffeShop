using Microsoft.AspNetCore.Identity;

namespace CoffeShop.Api.Security;

public class ApplicationSecurityUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}