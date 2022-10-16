namespace CoffeShop.Api.Authentication;

public interface IUserIdentityProfileProvider
{
    string UserName { get; }
    string Email { get; } 
    string RoleName{ get; }
}