using CoffeeShop.Domain.Entities.Identity;

namespace CoffeShop.Api.dto.Ui;

public class IdentityCredentialUi
{
    public long Id { get; set; }

    public string? Login { get; set; }

    public string? RefreshToken { get; set; }

    public DateTimeOffset? ValidTo { get; set; }
}

