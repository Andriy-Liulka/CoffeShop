using CoffeeShop.BusinessLogic.Exceptions;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using FluentValidation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CoffeeShop.BusinessLogic.Validation;

public class ValidatorsFactory : IValidatorsFactory
{
    public TFactory?  Generate<TEntity,TFactory>() 
        where TEntity :class,new()
        where TFactory : AbstractValidator<TEntity>,new()
        =>  typeof(TEntity).Name switch
        {
            nameof(BonusCoffee) => new BonusCoffeeValidator() as TFactory,
            nameof(Coffee) => new CoffeeValidator() as TFactory,
            nameof(DiscountCoffee) => new DiscountCoffeeValidator() as TFactory,
            nameof(Discount) => new DiscountValidator() as TFactory,
            nameof(Order) => new OrderValidator() as TFactory,
            nameof(OrderVolumeCoffee) => new OrderVolumeCoffeeValidator() as TFactory,
            nameof(Role) => new RoleValidator() as TFactory,
            nameof(User) => new UserValidator() as TFactory,
            nameof(Volume) => new VolumeValidator() as TFactory,
            nameof(LoginModel) => new LoginModelValidator() as TFactory,
            nameof(RegisterModel) => new RegisterModelValidator() as TFactory,
            _ => throw new InvalidValidatorException()
        };
}
