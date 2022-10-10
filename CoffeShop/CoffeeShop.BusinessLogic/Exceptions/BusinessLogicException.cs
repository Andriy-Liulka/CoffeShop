namespace CoffeeShop.BusinessLogic.Exceptions;

public abstract class BusinessLogicException : Exception
{
    public BusinessLogicException(string errorMessage):base(errorMessage) { }
}