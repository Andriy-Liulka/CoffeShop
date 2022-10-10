using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;
using CoffeeShop.BusinessLogic.Validation.Common;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class RegisterModelValidator : AbstractValidator<RegisterModel> , ICustomValidator
{
    public RegisterModelValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
        RuleFor(x => x.LastName).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
        RuleFor(x => x.Email).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
        RuleFor(x => x.Password).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
    }
}