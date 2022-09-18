using CoffeeShop.Domain.Entities.Identity;

namespace CoffeShop.Api.dto.Ui;

public class RoleUi
{
    public string Name { get; set; }

    public virtual IList<UserUi>? Users { get; set; }
}

