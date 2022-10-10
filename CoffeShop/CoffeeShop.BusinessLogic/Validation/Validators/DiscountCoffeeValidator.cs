using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class DiscountCoffeeValidator : AbstractValidator<DiscountCoffee>, ICustomValidator
{
    public DiscountCoffeeValidator()
    {
            
    }
}