namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;

public class RegisterModel
{
    public string Login
    {
        get => $"{FirstName}{LastName}";
        set => value = $"{FirstName}{LastName}";
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}