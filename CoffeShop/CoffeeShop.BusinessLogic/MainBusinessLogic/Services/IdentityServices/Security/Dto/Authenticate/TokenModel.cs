namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;

public class TokenModel
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}