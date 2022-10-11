namespace CoffeeShop.Domain.Entities.Identity;

public class IdentityCredential
{
    public string Login { get; set; }

    public virtual User? User { get; set; }
    public string? RefreshToken { get; set; }

    public DateTimeOffset? ValidTo { get; set; }
}