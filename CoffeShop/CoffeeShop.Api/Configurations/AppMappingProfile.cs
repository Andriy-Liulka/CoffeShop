using AutoMapper;
using CoffeeShop.BusinessLogic.Dto;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.Dto.Authenticate;
using CoffeShop.Api.dto.Common;
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
    }
}