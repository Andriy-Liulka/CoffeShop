namespace CoffeShop.Api.Security.AuthModels.CommonModels;

public class TokenModel
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}