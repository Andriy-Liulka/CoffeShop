using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IActionResult> GetAllAsync()
        => new OkObjectResult(await _userRepository.GetAllAsync());

    public async Task<IActionResult> GetAsync(string login)
        => new OkObjectResult(await _userRepository.GetAsync(login));

    public async Task<IActionResult> CreateAsync(User user)
        => new OkObjectResult(await _userRepository.CreateAsync(user));

    public async Task<IActionResult> UpdateAsync(User user)
        => new OkObjectResult(await _userRepository.UpdateAsync(user));

    public async Task<IActionResult> DeleteAsync(User user)
        => new OkObjectResult(await _userRepository.DeleteAsync(user));
}