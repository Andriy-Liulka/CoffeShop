namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.dto.Authenticate;

public class TokenModel
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}