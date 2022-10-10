using CoffeeShop.BusinessLogic.Validation.Common;
using CoffeeShop.Domain.Entities;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class BonusCoffeeValidator : AbstractValidator<BonusCoffee>, ICustomValidator
{
    public BonusCoffeeValidator()
    {
    }
}