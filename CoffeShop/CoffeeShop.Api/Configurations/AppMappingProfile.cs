using AutoMapper;
using CoffeeShop.BusinessLogic.Dto;
using CoffeShop.Api.Dto.Authenticate;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.dto.Authenticate;
using CoffeShop.Api.Dto;

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