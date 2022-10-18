using CoffeeShop.BusinessLogic.MainBusinessLogic.Services;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.DataAccess.Common;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountRepositories;
using CoffeeShop.Domain.Entities;
using FluentAssertions;
using Moq;
using FluentValidation.TestHelper;

namespace CoffeeShop.Tests.UnitTests
{
    public class DiscountTests
    {
        private readonly Fixture _fixture;
        private Mock<DiscountService> _discountService;
        private readonly Mock<IDiscountRepository> _mockRepository;
        private readonly Mock<MainValidator> _mockValidator;
        public DiscountTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mockRepository = new Mock<IDiscountRepository>();
            _mockValidator = new Mock<MainValidator>(new Mock<ValidatorsFactory>().Object);
        }
        [Fact]
        public async void GetAsyncTest()
        {
            //Arrange
            var volume = _fixture.Create<Discount>();

            _mockRepository.Setup(x => x.GetAsync(volume.Id)).ReturnsAsync(volume);

            _discountService = new Mock<DiscountService>(_mockRepository.Object, _mockValidator.Object);

            //Act
            var volumeObj = await _discountService.Object.GetAsync((int)volume.Id);

            //Assert
            volumeObj.Should().BeOfType<Discount>();
            volumeObj.Should().NotBeNull();
            Assert.True(volumeObj.Equals(volume));
            _mockRepository.Verify(service => service.GetAsync(volume.Id));
        }
        [Fact]
        public void ValidatorTest()
        {
            var discount = _fixture.Create<Discount>();
            discount.Percent = 100;

            var validator = _mockValidator.Object.GetValidator<Discount, DiscountValidator>();

            var validationResult = validator.TestValidate(discount);

            validationResult.ShouldNotHaveAnyValidationErrors();
        }
        [Fact]
        public async void GetAllAsyncTest()
        {
            //Arrange
            var discounts = _fixture.CreateMany<Discount>(10);

            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(discounts);

            _discountService = new Mock<DiscountService>(_mockRepository.Object, _mockValidator.Object);

            //Act
            var producedDiscounts = await _discountService.Object.GetAllAsync();

            //Assert
            _mockRepository.Verify(service => service.GetAllAsync());
            Assert.Equal(discounts, producedDiscounts);
        }

        [Fact]
        public async void CreateAsyncDiscountTest()
        {
            var discount = _fixture.Create<Discount>();
            discount.Percent = 100;

            _mockRepository
                .Setup(x => x.CreateAsync(discount))
                .ReturnsAsync(MessageCreator.SuccessfulCreateMessage<Discount>());

            _discountService = new Mock<DiscountService>(_mockRepository.Object, _mockValidator.Object);

            var result = await _discountService.Object.CreateAsync(discount);

            _mockRepository.Verify(service => service.CreateAsync(discount));

            Assert.Equal(MessageCreator.SuccessfulCreateMessage<Discount>(), result);
        }

        [Fact]
        public async void UpdateAsyncDiscountTest()
        {
            var discount = _fixture.Create<Discount>();
            discount.Percent = 100;

            _mockRepository
                .Setup(x => x.UpdateAsync(discount))
                .ReturnsAsync(MessageCreator.SuccessfulUpdateMessage<Discount>());

            _discountService = new Mock<DiscountService>(_mockRepository.Object, _mockValidator.Object);

            var result = await _discountService.Object.UpdateAsync(discount);

            _mockRepository.Verify(service => service.UpdateAsync(discount));

            Assert.Equal(MessageCreator.SuccessfulUpdateMessage<Discount>(), result);
        }

        [Fact]
        public async void DeleteAsyncDiscountTest()
        {
            var discount = _fixture.Create<Discount>();
            discount.Percent = 100;

            _mockRepository
                .Setup(x => x.DeleteAsync(discount))
                .ReturnsAsync(MessageCreator.SuccessfulDeleteMessage<Discount>());

            _discountService = new Mock<DiscountService>(_mockRepository.Object, _mockValidator.Object);

            var result = await _discountService.Object.DeleteAsync(discount);

            _mockRepository.Verify(service => service.DeleteAsync(discount));

            Assert.Equal(MessageCreator.SuccessfulDeleteMessage<Discount>(), result);
        }

        [Fact]
        public void GetAllAsyncFixtureTest()
        {
            var discounts = _fixture.CreateMany<Discount>(100).OrderBy(x => x.Id);

            discounts.Should().BeInAscendingOrder(x => x.Id);
        }
    }
}
