using CoffeeShop.BusinessLogic.Authentication;
using CoffeeShop.BusinessLogic.Common;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.DataAccess.Common;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.Identity;
using CoffeShop.Api.Authentication;
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
    private readonly Mock<CommonChecker> _commonChecker;
    public UserTests()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _mockRepository = new Mock<IUserRepository>();
        _mockValidator = new Mock<MainValidator>(new Mock<ValidatorsFactory>().Object);
        _commonChecker = new Mock<CommonChecker>(new Mock<IUserIdentityProfileProvider>().Object);
    }
    [Fact]
    public async void GetAsyncTest()
    {
        //Arrange
        var user = _fixture.Create<User>();

        _mockRepository.Setup(x => x.GetAsync(user.Login)).ReturnsAsync(user);
        var mockUserIdentityProfileProvider = new Mock<IUserIdentityProfileProvider>();
        var mockCommonChecker = new Mock<CommonChecker>(mockUserIdentityProfileProvider.Object);
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
    //[Fact]
    //public async void GetAllAsyncTest()
    //{
    //    //Arrange
    //    var coffees = _fixture.CreateMany<Coffee>(10);

    //    _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(coffees);

    //    _userService = new Mock<CoffeeService>(_mockRepository.Object, _mockValidator.Object);

    //    //Act
    //    var producedCoffees = await _userService.Object.GetAllAsync();

    //    //Assert
    //    _mockRepository.Verify(service => service.GetAllAsync());
    //    Assert.Equal(coffees, producedCoffees);
    //}

    //[Fact]
    //public async void CreateAsyncCoffeeTest()
    //{
    //    var coffee = _fixture.Create<Coffee>();

    //    _mockRepository
    //        .Setup(x => x.CreateAsync(coffee))
    //        .ReturnsAsync(MessageCreator.SuccessfulCreateMessage<Coffee>());

    //    _userService = new Mock<CoffeeService>(_mockRepository.Object, _mockValidator.Object);

    //    var result = await _userService.Object.CreateAsync(coffee);

    //    _mockRepository.Verify(service => service.CreateAsync(coffee));

    //    Assert.Equal(MessageCreator.SuccessfulCreateMessage<Coffee>(), result);
    //}

    //[Fact]
    //public async void UpdateAsyncCoffeeTest()
    //{
    //    var coffee = _fixture.Create<Coffee>();

    //    _mockRepository
    //        .Setup(x => x.UpdateAsync(coffee))
    //        .ReturnsAsync(MessageCreator.SuccessfulUpdateMessage<Coffee>());

    //    _userService = new Mock<CoffeeService>(_mockRepository.Object, _mockValidator.Object);

    //    var result = await _userService.Object.UpdateAsync(coffee);

    //    _mockRepository.Verify(service => service.UpdateAsync(coffee));

    //    Assert.Equal(MessageCreator.SuccessfulUpdateMessage<Coffee>(), result);
    //}

    //[Fact]
    //public async void DeleteAsyncCoffeeTest()
    //{
    //    var coffee = _fixture.Create<Coffee>();

    //    _mockRepository
    //        .Setup(x => x.DeleteAsync(coffee))
    //        .ReturnsAsync(MessageCreator.SuccessfulDeleteMessage<Coffee>());

    //    _userService = new Mock<CoffeeService>(_mockRepository.Object, _mockValidator.Object);

    //    var result = await _userService.Object.DeleteAsync(coffee);

    //    _mockRepository.Verify(service => service.DeleteAsync(coffee));

    //    Assert.Equal(MessageCreator.SuccessfulDeleteMessage<Coffee>(), result);
    //}

    //[Fact]
    //public void GetAllAsyncFixtureTest()
    //{
    //    var coffees = _fixture.CreateMany<Coffee>(100).OrderBy(x => x.Id);

    //    coffees.Should().BeInAscendingOrder(x => x.Id);
    //}
}

