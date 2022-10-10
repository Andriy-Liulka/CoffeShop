
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation;

public interface IValidatorsFactory
{
    public TFactory? Generate<TEntity, TFactory>()
        where TEntity : class, new()
        where TFactory : AbstractValidator<TEntity>, new();
}