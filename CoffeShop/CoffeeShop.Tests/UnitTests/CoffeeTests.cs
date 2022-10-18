
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services;
using CoffeeShop.Domain.Entities;
using Moq;
using FluentAssertions;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.DataAccess.Common;
using FluentValidation;
using FluentValidation.TestHelper;
using CoffeeShop.BusinessLogic.Validation.Validators;

namespace CoffeeShop.Tests.UnitTests;
public class CoffeeTests
{
    private readonly Fixture _fixture;
    private Mock<CoffeeService> _coffeeService;
    private readonly Mock<ICoffeeRepository> _mockRepository;
    private readonly Mock<MainValidator> _mockValidator;
    public CoffeeTests()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _mockRepository = new Mock<ICoffeeRepository>();
        _mockValidator = new Mock<MainValidator>(new Mock<ValidatorsFactory>().Object);
    }
    [Fact]
    public async void GetAsyncTest()
    {
        //Arrange
        var coffee = _fixture.Create<Coffee>();

        _mockRepository.Setup( x =>  x.GetAsync(coffee.Id)).ReturnsAsync(coffee);

        _coffeeService = new Mock<CoffeeService>(_mockRepository.Object, _mockValidator.Object);

        //Act
        var coffeeObj = await _coffeeService.Object.GetAsync((int)coffee.Id);

        //Assert
        coffeeObj.Should().BeOfType<Coffee>();
        coffeeObj.Should().NotBeNull();
        Assert.True(coffeeObj.Equals(coffee));
        _mockRepository.Verify(service => service.GetAsync(coffee.Id));
    }
    [Fact]
    public void ValidatorTest()
    {
        var coffee = _fixture.Create<Coffee>();
        coffee.Name = "gggggfgffffffffffffffffffffffffffffgfgfgghghghghghghghgghghghhghghghhghhghghghghghghhghghghghghghghghghghghghghghghghghghhg";

        var validator = _mockValidator.Object.GetValidator<Coffee, CoffeeValidator>();

        var validationResult = validator.TestValidate(coffee);

        validationResult.ShouldHaveValidationErrorFor(x => x.Name);
    }
    [Fact]
    public async void GetAllAsyncTest()
    {
        //Arrange
        var coffees = _fixture.CreateMany<Coffee>(10);

        _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(coffees);

        _coffeeService = new Mock<CoffeeService>(_mockRepository.Object, _mockValidator.Object);

        //Act
        var producedCoffees = await _coffeeService.Object.GetAllAsync();

        //Assert
        _mockRepository.Verify(service => service.GetAllAsync());
        Assert.Equal(coffees, producedCoffees);
    }

    [Fact]
    public async void CreateAsyncCoffeeTest()
    {
        var coffee = _fixture.Create<Coffee>();

        _mockRepository
            .Setup(x => x.CreateAsync(coffee))
            .ReturnsAsync(MessageCreator.SuccessfulCreateMessage<Coffee>());

        _coffeeService = new Mock<CoffeeService>(_mockRepository.Object, _mockValidator.Object);
        
        var result = await _coffeeService.Object.CreateAsync(coffee);

        _mockRepository.Verify(service => service.CreateAsync(coffee));

        Assert.Equal(MessageCreator.SuccessfulCreateMessage<Coffee>(), result);
    }

    [Fact]
    public async void UpdateAsyncCoffeeTest()
    {
        var coffee = _fixture.Create<Coffee>();

        _mockRepository
            .Setup(x => x.UpdateAsync(coffee))
            .ReturnsAsync(MessageCreator.SuccessfulUpdateMessage<Coffee>());

        _coffeeService = new Mock<CoffeeService>(_mockRepository.Object, _mockValidator.Object);

        var result = await _coffeeService.Object.UpdateAsync(coffee);

        _mockRepository.Verify(service => service.UpdateAsync(coffee));

        Assert.Equal(MessageCreator.SuccessfulUpdateMessage<Coffee>(), result);
    }

    [Fact]
    public async void DeleteAsyncCoffeeTest()
    {
        var coffee = _fixture.Create<Coffee>();

        _mockRepository
            .Setup(x => x.DeleteAsync(coffee))
            .ReturnsAsync(MessageCreator.SuccessfulDeleteMessage<Coffee>());

        _coffeeService = new Mock<CoffeeService>(_mockRepository.Object, _mockValidator.Object);

        var result = await _coffeeService.Object.DeleteAsync(coffee);

        _mockRepository.Verify(service => service.DeleteAsync(coffee));

        Assert.Equal(MessageCreator.SuccessfulDeleteMessage<Coffee>(), result);
    }

    [Fact]
    public void GetAllAsyncFixtureTest()
    {
        var coffees = _fixture.CreateMany<Coffee>(100).OrderBy(x=>x.Id);

        coffees.Should().BeInAscendingOrder(x => x.Id);
    }
}