using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;
using CoffeeShop.BusinessLogic.Validation.Common;
using FluentValidation;

namespace CoffeeShop.BusinessLogic.Validation.Validators;

public class LoginModelValidator  : AbstractValidator<LoginModel> , ICustomValidator
{
    public LoginModelValidator()
    {
        RuleFor(x => x.Username).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
        RuleFor(x => x.Password).NotEmpty().NotNull().Must(CustomRules.StringLengthRule);
    }
}