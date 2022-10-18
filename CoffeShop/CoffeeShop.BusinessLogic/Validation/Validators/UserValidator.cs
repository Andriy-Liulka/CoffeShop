using CoffeeShop.BusinessLogic.Validation.Common;
using CoffeeShop.Domain.Entities.Identity;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class UserValidator : AbstractValidator<User> , ICustomValidator
{
    public UserValidator()
    {
        RuleFor(x => x.LastName).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
        RuleFor(x => x.FirstName).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
        RuleFor(x => x.Login).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
        RuleFor(x => x.Email).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
    }
}