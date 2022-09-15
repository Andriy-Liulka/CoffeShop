using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;
using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
        => await _userRepository.GetAllAsync();

    public async Task<User?> GetAsync(string login)
        => await _userRepository.GetAsync(login);
    public async Task CreateAsync(User user)
        => await _userRepository.CreateAsync(user);

    public async Task UpdateAsync(User user)
        => await _userRepository.UpdateAsync(user);

    public async Task DeleteAsync(User user)
        => await _userRepository.DeleteAsync(user);
}