using CoffeeShop.Domain.Entities.Identity;

namespace CoffeeShop.BusinessLogic.Common;

public static class UpdateIdentityCredentialExtension
{
    public static IdentityCredential UpdateWith(this IdentityCredential obj, Func<IdentityCredential> assigner)
    {
        var type = typeof(IdentityCredential);
        var properties = type.GetProperties();
        var newObj = assigner.Invoke();

        properties.Where(x => x.CanRead && x.CanWrite && x.Name is not "Id").ToList().ForEach(x =>
        {
            var value = x.GetValue(newObj);
            if (value != default)
                x.SetValue(obj, value);
        });
        return obj;
    }
}