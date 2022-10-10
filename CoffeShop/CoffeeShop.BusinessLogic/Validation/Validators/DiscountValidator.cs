using CoffeeShop.BusinessLogic.Validation.Common;
using CoffeeShop.Domain.Entities;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class DiscountValidator: AbstractValidator<Discount>, ICustomValidator
{
    public DiscountValidator()
    {
        RuleFor(x => x.Percent).Must(CustomRules.PercentageRule);
    }
}