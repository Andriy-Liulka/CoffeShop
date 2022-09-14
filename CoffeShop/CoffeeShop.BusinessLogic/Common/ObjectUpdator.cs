namespace CoffeeShop.BusinessLogic.Common;

public class ObjectUpdator
{
    public static void UpdateObjWithValues<TEntity>(ref TEntity obj,Func<TEntity> assigner)
    {
        var type = typeof(TEntity);
        var properties=type.GetProperties();
        var newObj = assigner.Invoke();
        
        foreach (var property in properties.Where(x=>x.CanRead && x.CanWrite && x.Name is not "Id").ToList())
        {
            var value = property.GetValue(newObj);
            if (value != default)
                property.SetValue(obj, value);
        }
    }
}