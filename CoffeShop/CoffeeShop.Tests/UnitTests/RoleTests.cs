using CoffeeShop.BusinessLogic.MainBusinessLogic.Services;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.Domain.Entities;
using Moq;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.RoleRepositories;
using CoffeeShop.Domain.Entities.Identity;
using FluentAssertions;

namespace CoffeeShop.Tests.UnitTests;

public class RoleTests
{
    private readonly Fixture _fixture;
    private Mock<RoleService> _roleService;
    private readonly Mock<IRoleRepository> _mockRepository;
    public RoleTests()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _mockRepository = new Mock<IRoleRepository>();
    }
    [Fact]
    public async void GetAsyncTest()
    {
        //Arrange
        var role = _fixture.Create<Role>();

        _mockRepository.Setup(x => x.GetAsync(role.Name)).ReturnsAsync(role);

        _roleService = new Mock<RoleService>(_mockRepository.Object);

        //Act
        var roleObj = await _roleService.Object.GetAsync(role.Name);

        //Assert
        roleObj.Should().BeOfType<Role>();
        roleObj.Should().NotBeNull();
        Assert.True(roleObj.Equals(role));
        _mockRepository.Verify(service => service.GetAsync(role.Name));
    }
    [Fact]
    public async void GetAllAsyncTest()
    {
        //Arrange
        var roles = _fixture.CreateMany<Role>(10);

        _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(roles);

        _roleService = new Mock<RoleService>(_mockRepository.Object);

        //Act
        var producedCoffees = await _roleService.Object.GetAllAsync();

        //Assert
        _mockRepository.Verify(service => service.GetAllAsync());
        Assert.Equal(roles, producedCoffees);
    }
}

