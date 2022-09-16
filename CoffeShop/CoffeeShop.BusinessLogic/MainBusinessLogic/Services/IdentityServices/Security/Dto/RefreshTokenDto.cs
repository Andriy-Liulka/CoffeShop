namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto;

public class RefreshTokenDto
{
    public string RefreshToken { get; set; }
    public DateTime ValidTo { get; set; }
}