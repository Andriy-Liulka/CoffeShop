using CoffeeShop.BusinessLogic.MainBusinessLogic.Services;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.DataAccess.Common;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;
using CoffeeShop.Domain.Entities;
using FluentAssertions;
using Moq;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderRepositories;
using FluentValidation.TestHelper;

namespace CoffeeShop.Tests.UnitTests
{
    public class OrderTests
    {
        private readonly Fixture _fixture;
        private Mock<OrderService> _orderService;
        private readonly Mock<IOrderRepository> _mockRepository;
        private readonly Mock<MainValidator> _mockValidator;
        public OrderTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mockRepository = new Mock<IOrderRepository>();
            _mockValidator = new Mock<MainValidator>(new Mock<ValidatorsFactory>().Object);
        }
        [Fact]
        public async void GetAsyncTest()
        {
            //Arrange
            var order = _fixture.Create<Order>();

            _mockRepository.Setup(x => x.GetAsync(order.Id)).ReturnsAsync(order);

            _orderService = new Mock<OrderService>(_mockRepository.Object, _mockValidator.Object);

            //Act
            var orderObj = await _orderService.Object.GetAsync((int)order.Id);

            //Assert
            orderObj.Should().BeOfType<Order>();
            orderObj.Should().NotBeNull();
            Assert.True(orderObj.Equals(order));
            _mockRepository.Verify(service => service.GetAsync(order.Id));
        }
        [Fact]
        public void ValidatorTest()
        {
            var order = _fixture.Create<Order>();

            var validator = _mockValidator.Object.GetValidator<Order, OrderValidator>();

            var validationResult = validator.TestValidate(order);

            validationResult.ShouldNotHaveAnyValidationErrors();
        }
        [Fact]
        public async void GetAllAsyncTest()
        {
            //Arrange
            var orders = _fixture.CreateMany<Order>(10);

            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(orders);

            _orderService = new Mock<OrderService>(_mockRepository.Object, _mockValidator.Object);

            //Act
            var producedOrders = await _orderService.Object.GetAllAsync();

            //Assert
            _mockRepository.Verify(service => service.GetAllAsync());
            Assert.Equal(orders, producedOrders);
        }

        [Fact]
        public async void CreateAsyncOrderTest()
        {
            var order = _fixture.Create<Order>();

            _mockRepository
                .Setup(x => x.CreateAsync(order))
                .ReturnsAsync(MessageCreator.SuccessfulCreateMessage<Order>());

            _orderService = new Mock<OrderService>(_mockRepository.Object, _mockValidator.Object);

            var result = await _orderService.Object.CreateAsync(order);

            _mockRepository.Verify(service => service.CreateAsync(order));

            Assert.Equal(MessageCreator.SuccessfulCreateMessage<Order>(), result);
        }

        [Fact]
        public async void UpdateAsyncOrderTest()
        {
            var order = _fixture.Create<Order>();

            _mockRepository
                .Setup(x => x.UpdateAsync(order))
                .ReturnsAsync(MessageCreator.SuccessfulUpdateMessage<Order>());

            _orderService = new Mock<OrderService>(_mockRepository.Object, _mockValidator.Object);

            var result = await _orderService.Object.UpdateAsync(order);

            _mockRepository.Verify(service => service.UpdateAsync(order));

            Assert.Equal(MessageCreator.SuccessfulUpdateMessage<Order>(), result);
        }

        [Fact]
        public async void DeleteAsyncOrderTest()
        {
            var order = _fixture.Create<Order>();

            _mockRepository
                .Setup(x => x.DeleteAsync(order))
                .ReturnsAsync(MessageCreator.SuccessfulDeleteMessage<Order>());

            _orderService = new Mock<OrderService>(_mockRepository.Object, _mockValidator.Object);

            var result = await _orderService.Object.DeleteAsync(order);

            _mockRepository.Verify(service => service.DeleteAsync(order));

            Assert.Equal(MessageCreator.SuccessfulDeleteMessage<Order>(), result);
        }

        [Fact]
        public void GetAllAsyncFixtureTest()
        {
            var orders = _fixture.CreateMany<Order>(100).OrderBy(x => x.Id);

            orders.Should().BeInAscendingOrder(x => x.Id);
        }
    }
}
