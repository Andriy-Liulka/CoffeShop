namespace CoffeShop.Api.dto;

public class RefreshTokenDto
{
    public string RefreshToken { get; set; }
    public DateTime ValidTo { get; set; }
}