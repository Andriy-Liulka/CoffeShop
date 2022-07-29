namespace CoffeeShop.DataAccess.Common;

public static class TableNameCreator
{
    public static string CreateDefaultTableName<TEntity>() =>
        nameof(TEntity) + "s";
}