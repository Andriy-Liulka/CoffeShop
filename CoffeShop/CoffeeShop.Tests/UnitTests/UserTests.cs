using CoffeeShop.BusinessLogic.Common.CommonChecker;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.DataAccess.Common;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;
using CoffeeShop.Domain.Entities.Identity;
using FluentAssertions;
using FluentValidation.TestHelper;
using Moq;

namespace CoffeeShop.Tests.UnitTests;

public class UserTests
{
    private readonly Fixture _fixture;
    private Mock<UserService> _userService;
    private readonly Mock<IUserRepository> _mockRepository;
    private readonly Mock<MainValidator> _mockValidator;
    private readonly Mock<ICommonChecker> _commonChecker;
    public UserTests()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _mockRepository = new Mock<IUserRepository>();
        _mockValidator = new Mock<MainValidator>(new Mock<ValidatorsFactory>().Object);
        _commonChecker = new Mock<ICommonChecker>();
    }
    [Fact]
    public async void GetAsyncTest()
    {
        //Arrange
        var user = _fixture.Create<User>();

        _mockRepository.Setup(x => x.GetAsync(user.Login)).ReturnsAsync(user);

        var mockCommonChecker = new Mock<ICommonChecker>();
        _userService = new Mock<UserService>(
            _mockRepository.Object,
            _mockValidator.Object,
            mockCommonChecker.Object);
        //Act
        var userObj = await _userService.Object.GetAsync(user.Login);

        //Assert
        userObj.Should().BeOfType<User>();
        userObj.Should().NotBeNull();
        Assert.True(userObj?.Equals(userObj));
        _mockRepository.Verify(service => service.GetAsync(userObj.Login));
    }
    [Fact]
    public void ValidatorTest()
    {
        var user = _fixture.Create<User>();
        user.LastName = "gggggfgffffffffffffffffffffffffffffgfgfgghghghghghghghgghghghhghghghhghhghghghghghghhghghghghghghghghghghghghghghghghghghhg";

        var validator = _mockValidator.Object.GetValidator<User, UserValidator>();

        var validationResult = validator.TestValidate(user);

        validationResult.ShouldHaveValidationErrorFor(x => x.LastName);
        validationResult.ShouldHaveValidationErrorFor(x => x.Login);
    }
    [Fact]
    public async void GetAllAsyncTest()
    {
        //Arrange
        var users = _fixture.CreateMany<User>(10);

        _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(users);

        _userService = new Mock<UserService>(_mockRepository.Object, _mockValidator.Object, _commonChecker.Object);

        //Act
        var producedCoffees = await _userService.Object.GetAllAsync();

        //Assert
        _mockRepository.Verify(service => service.GetAllAsync());
        Assert.Equal(users, producedCoffees);
    }

    [Fact]
    public async void CreateAsyncUserTest()
    {
        var user = _fixture.Create<User>();

        _mockRepository
            .Setup(x => x.CreateAsync(user))
            .ReturnsAsync(MessageCreator.SuccessfulCreateMessage<User>());

        _userService = new Mock<UserService>(_mockRepository.Object, _mockValidator.Object, _commonChecker.Object);

        var result = await _userService.Object.CreateAsync(user);

        _mockRepository.Verify(service => service.CreateAsync(user));

        Assert.Equal(MessageCreator.SuccessfulCreateMessage<User>(), result);
    }

    [Fact]
    public async void UpdateAsyncCoffeeTest()
    {
        var user = _fixture.Create<User>();

        _mockRepository
            .Setup(x => x.UpdateAsync(user))
            .ReturnsAsync(MessageCreator.SuccessfulUpdateMessage<User>());

        _commonChecker
            .Setup(x => x.CouldChangeUserData(user))
            .Returns(true);

        _userService = new Mock<UserService>(_mockRepository.Object, _mockValidator.Object, _commonChecker.Object);

        var result = await _userService.Object.UpdateAsync(user);

        _mockRepository.Verify(service => service.UpdateAsync(user));

        Assert.Equal(MessageCreator.SuccessfulUpdateMessage<User>(), result);
    }

    [Fact]
    public async void DeleteAsyncCoffeeTest()
    {
        var user = _fixture.Create<User>();

        _mockRepository
            .Setup(x => x.DeleteAsync(user))
            .ReturnsAsync(MessageCreator.SuccessfulDeleteMessage<User>());

        _commonChecker
            .Setup(x => x.CouldChangeUserData(user))
            .Returns(true);

        _userService = new Mock<UserService>(_mockRepository.Object, _mockValidator.Object, _commonChecker.Object);

        var result = await _userService.Object.DeleteAsync(user);

        _mockRepository.Verify(service => service.DeleteAsync(user));

        Assert.Equal(MessageCreator.SuccessfulDeleteMessage<User>(), result);
    }

    [Fact]
    public void GetAllAsyncFixtureTest()
    {
        var coffees = _fixture.CreateMany<User>(100).OrderBy(x => x.Login);

        coffees.Should().BeInAscendingOrder(x => x.Login);
    }
}

