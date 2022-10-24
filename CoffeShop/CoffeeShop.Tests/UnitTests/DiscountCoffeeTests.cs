using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using FluentAssertions;
using Moq;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountCoffeeRepositories;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.Tests.UnitTests;

public class DiscountCoffeeTests
{
    private readonly Fixture _fixture;
    private Mock<DiscountCoffeeService> _discountCoffeeService;
    private readonly Mock<IDiscountCoffeeRepository> _mockRepository;
    private readonly Mock<MainValidator> _mockValidator;
    public DiscountCoffeeTests()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _mockRepository = new Mock<IDiscountCoffeeRepository>();
        _mockValidator = new Mock<MainValidator>(new Mock<ValidatorsFactory>().Object);
    }
    [Fact]
 
    public async void GetAsyncTest()
    {
        //Arrange
        var discountCoffee = _fixture.Create<DiscountCoffee>();

        _mockRepository.Setup(x => x.GetAsync(discountCoffee.CoffeeId, discountCoffee.DiscountId)).ReturnsAsync(discountCoffee);

        _discountCoffeeService = new Mock<DiscountCoffeeService>(_mockRepository.Object, _mockValidator.Object);

        //Act
        var volumeObj = await _discountCoffeeService.Object.GetAsync((int)discountCoffee.CoffeeId, (int)discountCoffee.DiscountId);

        //Assert
        volumeObj.Should().BeOfType<DiscountCoffee>();
        volumeObj.Should().NotBeNull();
        Assert.True(volumeObj.Equals(discountCoffee));
        _mockRepository.Verify(service => service.GetAsync((int)discountCoffee.CoffeeId, (int)discountCoffee.DiscountId));
    }

    [Fact]
    public async void GetAllAsyncTest()
    {
        //Arrange
        var discountCoffees = _fixture.CreateMany<DiscountCoffee>(10);

        _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(discountCoffees);

        _discountCoffeeService = new Mock<DiscountCoffeeService>(_mockRepository.Object, _mockValidator.Object);

        //Act
        var producedDiscounts = await _discountCoffeeService.Object.GetAllAsync();

        //Assert
        _mockRepository.Verify(service => service.GetAllAsync());
        Assert.Equal(discountCoffees, producedDiscounts);
    }

    [Fact]
    public async void CreateAsyncDiscountTest()
    {
        var discountCoffee = _fixture.Create<DiscountCoffee>();

        _mockRepository
            .Setup(x => x.CreateAsync(discountCoffee))
            .ReturnsAsync(MessageCreator.SuccessfulCreateMessage<DiscountCoffee>());

        _discountCoffeeService = new Mock<DiscountCoffeeService>(_mockRepository.Object, _mockValidator.Object);

        var result = await _discountCoffeeService.Object.CreateAsync(discountCoffee);

        _mockRepository.Verify(service => service.CreateAsync(discountCoffee));

        Assert.Equal(MessageCreator.SuccessfulCreateMessage<DiscountCoffee>(), result);
    }

    [Fact]
    public async void UpdateAsyncDiscountTest()
    {
        var discountCoffee = _fixture.Create<DiscountCoffee>();

        _mockRepository
            .Setup(x => x.UpdateAsync(discountCoffee))
            .ReturnsAsync(MessageCreator.SuccessfulUpdateMessage<DiscountCoffee>());

        _discountCoffeeService = new Mock<DiscountCoffeeService>(_mockRepository.Object, _mockValidator.Object);

        var result = await _discountCoffeeService.Object.UpdateAsync(discountCoffee);

        _mockRepository.Verify(service => service.UpdateAsync(discountCoffee));

        Assert.Equal(MessageCreator.SuccessfulUpdateMessage<DiscountCoffee>(), result);
    }

    [Fact]
    public async void DeleteAsyncDiscountTest()
    {
        var discountCoffee = _fixture.Create<DiscountCoffee>();

        _mockRepository
            .Setup(x => x.DeleteAsync(discountCoffee))
            .ReturnsAsync(MessageCreator.SuccessfulDeleteMessage<DiscountCoffee>());

        _discountCoffeeService = new Mock<DiscountCoffeeService>(_mockRepository.Object, _mockValidator.Object);

        var result = await _discountCoffeeService.Object.DeleteAsync(discountCoffee);

        _mockRepository.Verify(service => service.DeleteAsync(discountCoffee));

        Assert.Equal(MessageCreator.SuccessfulDeleteMessage<DiscountCoffee>(), result);
    }

    [Fact]
    public void GetAllAsyncFixtureTest()
    {
        var discounts = _fixture.CreateMany<DiscountCoffee>(100).OrderBy(x => x.CoffeeId );

        discounts.Should().BeInAscendingOrder(x => x.CoffeeId);
    }
}

