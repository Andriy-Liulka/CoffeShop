using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation
{
    public interface IMainValidator
    {
        TEntity Validate<TEntity, TFactory>(TEntity obj) 
            where TEntity : class, new()
            where TFactory : AbstractValidator<TEntity>, new();

       TFactory GetValidator<TEntity, TFactory>()
            where TEntity : class, new()
            where TFactory : AbstractValidator<TEntity>, new();
    }
}