using CoffeeShop.BusinessLogic.Common;
using CoffeeShop.BusinessLogic.Exceptions;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly MainValidator _validator;
    private readonly CommonChecker _commonChecker;

    public UserService(IUserRepository userRepository,MainValidator validator,CommonChecker commonChecker)
    {
        _userRepository = userRepository;
        _validator = validator;
        _commonChecker = commonChecker;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
        => await _userRepository.GetAllAsync();

    public async Task<User?> GetAsync(string login)
        => await _userRepository.GetAsync(login);

    public async Task<string> CreateAsync(User user)
    {
        _validator.Validate<User, UserValidator>(user);
        return await _userRepository.CreateAsync(user);
    }

    public async Task<string> UpdateAsync(User user)
    {
        if (!_commonChecker.CouldChangeUserData(user))
            throw new UnavailableChangesException();
        _validator.Validate<User, UserValidator>(user);
        return await _userRepository.UpdateAsync(user);
    }

    public async Task<string> DeleteAsync(User user)
    {
        if (!_commonChecker.CouldChangeUserData(user))
            throw new UnavailableChangesException();
        _validator.Validate<User, UserValidator>(user);
        return await _userRepository.DeleteAsync(user);
    }
}