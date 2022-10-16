using CoffeeShop.Domain.Constants;
using CoffeeShop.Domain.Entities.Identity;
using CoffeShop.Api.Authentication;

namespace CoffeeShop.BusinessLogic.Common;

public class CommonChecker
{
    private readonly IUserIdentityProfileProvider _identityProfileProvider;
    public CommonChecker(IUserIdentityProfileProvider identityProfileProvider)
    {
        _identityProfileProvider = identityProfileProvider;
    }
    public bool CouldChangeUserData(User user)
    {
        switch (user.RoleName)
        {
            case Roles.Customer when user.Login.Equals(_identityProfileProvider.UserName):
                return true;
            case Roles.Admin:
                return true;
            default: return false;
        }
    }
}