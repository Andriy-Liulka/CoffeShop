namespace CoffeShop.Api.Common;

public static class Translation
{
    public static string InternalServerErrorMessage = "Internal server error!";
    public const string EmptyStringMessage = "Your connection string is empty";
    public const string BadRequestObjectResultMessage = "Type-> {0} \n Message:\n {1}";
    public const string ErrorMiddlewareHandlingMessage = "Error happens during request \"{0}\"";

    public const string IncorrectUserDestinationMessage = "You cannot edit data of this user!";
}