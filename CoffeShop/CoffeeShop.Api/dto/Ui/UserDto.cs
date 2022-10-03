using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities;

namespace CoffeShop.Api.dto.Ui;

public class UserDto
{
    public string Login
    {
        get => $"{FirstName}{LastName}";
        set => value = $"{FirstName}{LastName}";
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public string? IdentityCredentialLogin { get; set; }

    public bool IsBlocked { get; set; }

    public string? AvatarImage { get; set; }

    public long Bonuses { get; set; }
    public string? RoleName { get; set; }
}

