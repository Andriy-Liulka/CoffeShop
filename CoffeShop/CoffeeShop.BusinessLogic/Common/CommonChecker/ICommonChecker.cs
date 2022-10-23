using CoffeeShop.Domain.Entities.Identity;

namespace CoffeeShop.BusinessLogic.Common.CommonChecker
{
    public interface ICommonChecker
    {
        bool CouldChangeUserData(User user);
    }
}