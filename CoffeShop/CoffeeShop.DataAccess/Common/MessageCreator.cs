namespace CoffeeShop.DataAccess.Common;

public static class MessageCreator
{
    public static string SuccessfulCreateMessage<T>()
        => $"Object {typeof(T)} was created successfully !";

    public static string SuccessfulUpdateMessage<T>()
        => $"Object {typeof(T)} was created successfully !";

    public static string SuccessfulDeleteMessage<T>()
        => $"Object {typeof(T)} was created successfully !";
}