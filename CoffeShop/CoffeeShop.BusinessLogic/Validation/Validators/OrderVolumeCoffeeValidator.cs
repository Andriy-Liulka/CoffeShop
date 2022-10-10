using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class OrderVolumeCoffeeValidator : AbstractValidator<OrderVolumeCoffee> , ICustomValidator
{
    public OrderVolumeCoffeeValidator()
    {
            
    }
}