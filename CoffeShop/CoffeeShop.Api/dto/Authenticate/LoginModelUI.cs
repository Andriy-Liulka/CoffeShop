using System.ComponentModel.DataAnnotations;

namespace CoffeShop.Api.Dto.Authenticate;

public class LoginModelUi
{
    [Required(ErrorMessage = "User Name is required")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}