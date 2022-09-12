using System.Security.AccessControl;

namespace CoffeeShop.Domain.Entities.Identity;

public class User
{
    public string Login
    {
        get => $"{FirstName}{LastName}";
        set => value = $"{FirstName}{LastName}";
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get;set; }
    
    public string PasswordHash { get; set; }
    
    public long? IdentityCredentialId { get; set; }
    public virtual IdentityCredential? IdentityCredential { get; set; }
    
    public bool IsBlocked { get; set; }
    
    public string AvatarImage { get; set; }
    
    public long Bonuses { get; set; }
    public long? RoleId { get; set; }
    public virtual Role? Role { get; set; }
    public virtual IList<Order>? Orders { get; set; }
}