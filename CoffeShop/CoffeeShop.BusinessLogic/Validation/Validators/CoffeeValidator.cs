using CoffeeShop.BusinessLogic.Validation.Common;
using CoffeeShop.Domain.Entities;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class CoffeeValidator : AbstractValidator<Coffee>, ICustomValidator
{
    public CoffeeValidator()
    {
        RuleFor(x => x.IsMilk).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
        RuleFor(x => x.Provider).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
    }
}