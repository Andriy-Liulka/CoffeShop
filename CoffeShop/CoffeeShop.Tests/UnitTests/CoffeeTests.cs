
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities;
using Moq;
using FluentAssertions;

namespace CoffeeShop.Tests.UnitTests;

public class UnitTest1
{
    private readonly Fixture _fixture;

    public UnitTest1()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }
    [Fact]
    public async void GetAsyncTest()
    {
        var mockCoffeeDbSet = Common.GetQueryableMockDbSetAsync(TestDataCreator.GetTestCoffeeData());
        
        var mockContext = new Mock<CoffeeShopContext>();

        mockContext.Setup(x=>x.Coffees).Returns(mockCoffeeDbSet);

        ICoffeeService coffeeService = new CoffeeService(context:mockContext.Object);

        var data = await coffeeService.GetAsync(1);

        Assert.Equal("Latte",data?.Name);
    }
    
    [Fact]
    public async void GetAsyncTest2()
    {
        var mockCoffeeDbSet = Common.GetQueryableMockDbSetAsyncCompleteImpl(TestDataCreator.GetTestCoffeeData());
        
        var mockContext = new Mock<CoffeeShopContext>();
        
        mockContext.Setup(x=>x.Coffees).Returns(mockCoffeeDbSet);

        ICoffeeService coffeeService = new CoffeeService(context:mockContext.Object);

        var data = await coffeeService.GetAsync(1);
        Assert.Equal("Latte",data?.Name);
        
        Assert.Equal("Americano", coffeeService.GetAsync(2).Result?.Name);
        Assert.Equal("Australia",coffeeService.GetAsync(5).Result?.Provider);
        Assert.Equal("Efiopia",coffeeService.GetAsync(7).Result?.Provider);

        var coffeService =(await coffeeService.GetAsync(2))?.Name;
        //TODO unpacking tasks 
        coffeService.Should().Be("Americano");
    }

    [Fact]
    public async void GetAllAsyncTest()
    {
        var mockCoffeeDbSet = Common.GetQueryableMockDbSetAsync(TestDataCreator.GetTestCoffeeData());
        var mockContext = new Mock<CoffeeShopContext>();

        mockContext.Setup(x=>x.Coffees).Returns(mockCoffeeDbSet);

        ICoffeeService coffeeService = new CoffeeService(context:mockContext.Object);

        var data=await coffeeService.GetAllAsync();

        data.Should().BeOfType<List<Coffee>>().And.BeInAscendingOrder(x=>x.Id);
    }
    
    [Fact]
    public void GetAllAsyncFixtureTest()
    {
        var coffees = _fixture.CreateMany<Coffee>();
        
       // _fixture.Create<Coffee>().

        coffees.Should().BeInAscendingOrder(x => x.Id);
    }
}