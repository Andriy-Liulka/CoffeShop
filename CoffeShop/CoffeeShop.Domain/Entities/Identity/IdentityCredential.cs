namespace CoffeeShop.Domain.Entities.Identity;

public class IdentityCredential
{
    public long Id { get; set; }
    
    public string? Login { get; set; }
    
    public virtual User? User { get; set; }
    public string? RefreshToken { get; set; }
    
    public DateTimeOffset? ValidTo { get; set; }
}