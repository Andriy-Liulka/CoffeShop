namespace CoffeeShop.Domain.Entities.Identity;

public class Role
{
    public long Id { get; set; }
    
    public string Name { get; set; }

    public virtual IList<User> Users { get; set; }
}