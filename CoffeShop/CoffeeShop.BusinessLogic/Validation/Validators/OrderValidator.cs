using CoffeeShop.BusinessLogic.Validation.Common;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Enums;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class OrderValidator : AbstractValidator<Order> , ICustomValidator
{
    public OrderValidator()
    {
        RuleFor(x => x.DeliveryWay).Must(CustomRules.DeliveryWaysRule);
    }
}