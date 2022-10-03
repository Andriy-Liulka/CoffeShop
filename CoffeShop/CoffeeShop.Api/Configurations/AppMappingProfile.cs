using AutoMapper;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using CoffeShop.Api.Dto.Authenticate;
using CoffeShop.Api.Dto.Input;

namespace CoffeShop.Api.Configurations;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<LoginModelDto, LoginModel>();
        CreateMap<RegisterModelDto, RegisterModel>();
        CreateMap<TokenModelDto, TokenModel>();
        CreateMap<BonusCoffeeDto, BonusCoffee>();
        CreateMap<CoffeeDto, Coffee>();
        CreateMap<DiscountCoffeeDto, DiscountCoffee>();
        CreateMap<DiscountDto, Discount>();
        CreateMap<IdentityCredentialDto, IdentityCredential>();
        CreateMap<OrderDto, Order>();
        CreateMap<OrderVolumeCoffeeDto, OrderVolumeCoffee>();
        CreateMap<RoleDto, Role>();
        CreateMap<UserDto, User>();
        CreateMap<VolumeDto,Volume>();
    }
}