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
    private readonly IRepository<User> _repository;
    private readonly IUserRepository _userRepository;
    public UserService(IRepository<User> repository,IUserRepository userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<User?> GetAsync(string login)
        => await _userRepository.GetAsync(login);
    public async Task CreateAsync(User user)
        => await _repository.CreateAsync(user);

    public async Task UpdateAsync(User user)
        => await _repository.UpdateAsync(user);

    public async Task DeleteAsync(User user)
        => await _repository.DeleteAsync(user);
}