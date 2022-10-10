using FluentValidation.Results;

namespace CoffeeShop.BusinessLogic.Exceptions;

public class FluentValidatorException : BusinessLogicException
{
    public FluentValidatorException(List<ValidationFailure> errors)
        :base(string.Join("\n",
            errors.Select(
                x=>$"Property {x.PropertyName}  failed validation. Error was: {x.ErrorMessage}")))
    {
            
    }
}