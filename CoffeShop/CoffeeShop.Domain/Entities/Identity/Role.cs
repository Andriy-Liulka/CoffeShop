namespace CoffeeShop.Domain.Entities.Identity;

public class Role
{
    public string Name { get; set; }

    public virtual IList<User>? Users { get; set; }
}