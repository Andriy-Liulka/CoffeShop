using CoffeeShop.BusinessLogic.Exceptions;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation;

public class MainValidator
{
    private readonly IValidatorsFactory _validatorsFactory;
    public MainValidator(IValidatorsFactory validatorsFactory)
    {
        _validatorsFactory = validatorsFactory;
    }

    public TEntity Validate<TEntity,TFactory>(TEntity obj) 
        where TEntity : class,new()
        where TFactory : AbstractValidator<TEntity>,new()
    {
        var validator = _validatorsFactory.Generate<TEntity,TFactory>();
        var result = validator?.Validate(obj);

        if (!result.IsValid)
            throw new FluentValidatorException(result.Errors);
        return obj;
    }
}