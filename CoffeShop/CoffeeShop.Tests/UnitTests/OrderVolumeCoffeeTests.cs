using CoffeeShop.BusinessLogic.MainBusinessLogic.Services;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.DataAccess.Common;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountRepositories;
using CoffeeShop.Domain.Entities;
using FluentAssertions;
using Moq;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderVolumeCoffeeRepositories;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using FluentValidation.TestHelper;

namespace CoffeeShop.Tests.UnitTests;

public class OrderVolumeCoffeeTests
{
    private readonly Fixture _fixture;
    private Mock<OrderVolumeCoffeeService> _orderVolumeCoffeeService;
    private readonly Mock<IOrderVolumeCoffeeRepository> _mockRepository;
    private readonly Mock<MainValidator> _mockValidator;
    public OrderVolumeCoffeeTests()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _mockRepository = new Mock<IOrderVolumeCoffeeRepository>();
        _mockValidator = new Mock<MainValidator>(new Mock<ValidatorsFactory>().Object);
    }
    [Fact]

    public async void GetAsyncTest()
    {
        //Arrange
        var orderVolumeCoffee = _fixture.Create<OrderVolumeCoffee>();

        _mockRepository.Setup(x => x.GetAsync(orderVolumeCoffee.Id)).ReturnsAsync(orderVolumeCoffee);

        _orderVolumeCoffeeService = new Mock<OrderVolumeCoffeeService>(_mockRepository.Object, _mockValidator.Object);

        //Act
        var volumeObj = await _orderVolumeCoffeeService.Object.GetAsync((int)orderVolumeCoffee.Id);

        //Assert
        volumeObj.Should().BeOfType<OrderVolumeCoffee>();
        volumeObj.Should().NotBeNull();
        Assert.True(volumeObj.Equals(orderVolumeCoffee));
        _mockRepository.Verify(service => service.GetAsync(orderVolumeCoffee.Id));
    }
    [Fact]
    public void ValidatorTest()
    {
        var orderVolumeCoffee = _fixture.Create<OrderVolumeCoffee>();

        var validator = _mockValidator.Object.GetValidator<OrderVolumeCoffee, OrderVolumeCoffeeValidator>();

        var validationResult = validator.TestValidate(orderVolumeCoffee);

        validationResult.ShouldNotHaveAnyValidationErrors();
    }
    [Fact]
    public async void GetAllAsyncTest()
    {
        //Arrange
        var orderVolumeCoffees = _fixture.CreateMany<OrderVolumeCoffee>(10);

        _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(orderVolumeCoffees);

        _orderVolumeCoffeeService = new Mock<OrderVolumeCoffeeService>(_mockRepository.Object, _mockValidator.Object);

        //Act
        var producedDiscounts = await _orderVolumeCoffeeService.Object.GetAllAsync();

        //Assert
        _mockRepository.Verify(service => service.GetAllAsync());
        Assert.Equal(orderVolumeCoffees, producedDiscounts);
    }

    [Fact]
    public async void CreateAsyncDiscountTest()
    {
        var orderVolumeCoffee = _fixture.Create<OrderVolumeCoffee>();

        _mockRepository
            .Setup(x => x.CreateAsync(orderVolumeCoffee))
            .ReturnsAsync(MessageCreator.SuccessfulCreateMessage<OrderVolumeCoffee>());

        _orderVolumeCoffeeService = new Mock<OrderVolumeCoffeeService>(_mockRepository.Object, _mockValidator.Object);

        var result = await _orderVolumeCoffeeService.Object.CreateAsync(orderVolumeCoffee);

        _mockRepository.Verify(service => service.CreateAsync(orderVolumeCoffee));

        Assert.Equal(MessageCreator.SuccessfulCreateMessage<OrderVolumeCoffee>(), result);
    }

    [Fact]
    public async void UpdateAsyncDiscountTest()
    {
        var orderVolumeCoffee = _fixture.Create<OrderVolumeCoffee>();

        _mockRepository
            .Setup(x => x.UpdateAsync(orderVolumeCoffee))
            .ReturnsAsync(MessageCreator.SuccessfulUpdateMessage<OrderVolumeCoffee>());

        _orderVolumeCoffeeService = new Mock<OrderVolumeCoffeeService>(_mockRepository.Object, _mockValidator.Object);

        var result = await _orderVolumeCoffeeService.Object.UpdateAsync(orderVolumeCoffee);

        _mockRepository.Verify(service => service.UpdateAsync(orderVolumeCoffee));

        Assert.Equal(MessageCreator.SuccessfulUpdateMessage<OrderVolumeCoffee>(), result);
    }

    [Fact]
    public async void DeleteAsyncDiscountTest()
    {
        var orderVolumeCoffee = _fixture.Create<OrderVolumeCoffee>();

        _mockRepository
            .Setup(x => x.DeleteAsync(orderVolumeCoffee))
            .ReturnsAsync(MessageCreator.SuccessfulDeleteMessage<OrderVolumeCoffee>());

        _orderVolumeCoffeeService = new Mock<OrderVolumeCoffeeService>(_mockRepository.Object, _mockValidator.Object);

        var result = await _orderVolumeCoffeeService.Object.DeleteAsync(orderVolumeCoffee);

        _mockRepository.Verify(service => service.DeleteAsync(orderVolumeCoffee));

        Assert.Equal(MessageCreator.SuccessfulDeleteMessage<OrderVolumeCoffee>(), result);
    }

    [Fact]
    public void GetAllAsyncFixtureTest()
    {
        var discounts = _fixture.CreateMany<OrderVolumeCoffee>(100).OrderBy(x => x.Id);

        discounts.Should().BeInAscendingOrder(x => x.Id);
    }
}


