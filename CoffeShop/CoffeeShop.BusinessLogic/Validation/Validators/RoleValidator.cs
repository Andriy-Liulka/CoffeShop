using CoffeeShop.Domain.Entities.Identity;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class RoleValidator : AbstractValidator<Role> , ICustomValidator
{
    public RoleValidator()
    {
            
    }   
}