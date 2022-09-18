using AutoMapper;
using CoffeeShop.BusinessLogic.Dto;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using CoffeShop.Api.dto.Common;
using CoffeShop.Api.dto.Ui;
using CoffeShop.Api.Dto.Authenticate;

namespace CoffeShop.Api.Configurations;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<LoginModelUi, LoginModel>();
        CreateMap<RegisterModelUi, RegisterModel>();
        CreateMap<TokenModelUi, TokenModel>();
        CreateMap<DiscountCoffeeGetAsyncDtoUi, DiscountCoffeeGetAsyncDto>();
        CreateMap<BonusCoffeeUi, BonusCoffee>();
        CreateMap<CoffeeUi, Coffee>();
        CreateMap<DiscountCoffeeUi, DiscountCoffee>();
        CreateMap<DiscountUi, Discount>();
        CreateMap<IdentityCredentialUi, IdentityCredential>();
        CreateMap<OrderUi, Order>();
        CreateMap<OrderVolumeCoffeeUi, OrderVolumeCoffee>();
        CreateMap<RoleUi, Role>();
        CreateMap<UserUi, User>();
        CreateMap<VolumeUi,Volume>();
    }
}