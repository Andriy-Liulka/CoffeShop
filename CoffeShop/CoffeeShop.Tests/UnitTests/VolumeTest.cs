using CoffeeShop.BusinessLogic.MainBusinessLogic.Services;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.DataAccess.Common;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;
using CoffeeShop.Domain.Entities;
using FluentAssertions;
using Moq;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.VolumeRepositories;
using FluentValidation.TestHelper;

namespace CoffeeShop.Tests.UnitTests
{
    public class VolumeTest
    {
        private readonly Fixture _fixture;
        private Mock<VolumeService> _volumeService;
        private readonly Mock<IVolumeRepository> _mockRepository;
        private readonly Mock<MainValidator> _mockValidator;
        public VolumeTest()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mockRepository = new Mock<IVolumeRepository>();
            _mockValidator = new Mock<MainValidator>(new Mock<ValidatorsFactory>().Object);
        }
        [Fact]
        public async void GetAsyncTest()
        {
            //Arrange
            var volume = _fixture.Create<Volume>();

            _mockRepository.Setup(x => x.GetAsync(volume.Id)).ReturnsAsync(volume);

            _volumeService = new Mock<VolumeService>(_mockRepository.Object, _mockValidator.Object);

            //Act
            var volumeObj = await _volumeService.Object.GetAsync((int)volume.Id);

            //Assert
            volumeObj.Should().BeOfType<Volume>();
            volumeObj.Should().NotBeNull();
            Assert.True(volumeObj.Equals(volume));
            _mockRepository.Verify(service => service.GetAsync(volume.Id));
        }
        [Fact]
        public void ValidatorTest()
        {
            var volume = _fixture.Create<Volume>();

            var validator = _mockValidator.Object.GetValidator<Volume, VolumeValidator>();

            var validationResult = validator.TestValidate(volume);

            validationResult.ShouldNotHaveAnyValidationErrors();
        }
        [Fact]
        public async void GetAllAsyncTest()
        {
            //Arrange
            var volumes = _fixture.CreateMany<Volume>(10);

            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(volumes);

            _volumeService = new Mock<VolumeService>(_mockRepository.Object, _mockValidator.Object);

            //Act
            var producedVolumes = await _volumeService.Object.GetAllAsync();

            //Assert
            _mockRepository.Verify(service => service.GetAllAsync());
            Assert.Equal(volumes, producedVolumes);
        }

        [Fact]
        public async void CreateAsyncVolumeTest()
        {
            var volume = _fixture.Create<Volume>();

            _mockRepository
                .Setup(x => x.CreateAsync(volume))
                .ReturnsAsync(MessageCreator.SuccessfulCreateMessage<Volume>());

            _volumeService = new Mock<VolumeService>(_mockRepository.Object, _mockValidator.Object);

            var result = await _volumeService.Object.CreateAsync(volume);

            _mockRepository.Verify(service => service.CreateAsync(volume));

            Assert.Equal(MessageCreator.SuccessfulCreateMessage<Volume>(), result);
        }

        [Fact]
        public async void UpdateAsyncVolumeTest()
        {
            var volume = _fixture.Create<Volume>();

            _mockRepository
                .Setup(x => x.UpdateAsync(volume))
                .ReturnsAsync(MessageCreator.SuccessfulUpdateMessage<Volume>());

            _volumeService = new Mock<VolumeService>(_mockRepository.Object, _mockValidator.Object);

            var result = await _volumeService.Object.UpdateAsync(volume);

            _mockRepository.Verify(service => service.UpdateAsync(volume));

            Assert.Equal(MessageCreator.SuccessfulUpdateMessage<Volume>(), result);
        }

        [Fact]
        public async void DeleteAsyncVolumeTest()
        {
            var volume = _fixture.Create<Volume>();

            _mockRepository
                .Setup(x => x.DeleteAsync(volume))
                .ReturnsAsync(MessageCreator.SuccessfulDeleteMessage<Volume>());

            _volumeService = new Mock<VolumeService>(_mockRepository.Object, _mockValidator.Object);

            var result = await _volumeService.Object.DeleteAsync(volume);

            _mockRepository.Verify(service => service.DeleteAsync(volume));

            Assert.Equal(MessageCreator.SuccessfulDeleteMessage<Volume>(), result);
        }

        [Fact]
        public void GetAllAsyncFixtureTest()
        {
            var volume = _fixture.CreateMany<Volume>(100).OrderBy(x => x.Id);

            volume.Should().BeInAscendingOrder(x => x.Id);
        }
    }
}
