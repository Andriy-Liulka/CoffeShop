using CoffeeShop.BusinessLogic.Validation.Common;
using CoffeeShop.Domain.Entities;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class VolumeValidator : AbstractValidator<Volume> , ICustomValidator
{
    public VolumeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Must(CustomRules.StringLengthRule);
        RuleFor(x => x.Capacity).Must(CustomRules.MaxCapacityRule);
    }
}