using AutoMapper;
using CoffeShop.Api.dto.Authenticate;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security.dto.Authenticate;

namespace CoffeShop.Api.Configurations;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<LoginModelUi,LoginModel>();
        CreateMap<RegisterModelUi,RegisterModel>();
        CreateMap<TokenModelUi,TokenModel>();
    }
}