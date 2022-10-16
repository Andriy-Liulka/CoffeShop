namespace CoffeeShop.BusinessLogic.Exceptions;

public class UnavailableChangesException : BusinessLogicException
{
    public UnavailableChangesException() : base("You cannot edit these data!")
    {
    }
}