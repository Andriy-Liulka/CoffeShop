namespace CoffeShop.Api.Dto.Input;

public class IdentityCredentialDto
{
    public long Id { get; set; }

    public string? Login { get; set; }

    public string? RefreshToken { get; set; }

    public DateTimeOffset? ValidTo { get; set; }
}

