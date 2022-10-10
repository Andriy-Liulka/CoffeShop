using CoffeeShop.Domain.Entities.Identity;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class UserValidator : AbstractValidator<User> , ICustomValidator
{
    public UserValidator()
    {
            
    }
}