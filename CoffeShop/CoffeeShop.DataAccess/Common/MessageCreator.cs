namespace CoffeeShop.DataAccess.Common;

public static class MessageCreator
{
    public static string SuccessfulCreateMessage<T>()
        => $"Object {nameof(T)} was created successfully !";

    public static string SuccessfulUpdateMessage<T>()
        => $"Object {nameof(T)} was created successfully !";

    public static string SuccessfulDeleteMessage<T>()
        => $"Object {nameof(T)} was created successfully !";
}