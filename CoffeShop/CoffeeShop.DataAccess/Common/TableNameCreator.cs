namespace CoffeeShop.DataAccess.Common;

public static class TableNameCreator
{
    public static string CreateDefaultTableName(Func<string> func)
        =>  func.Invoke()+"s";
}