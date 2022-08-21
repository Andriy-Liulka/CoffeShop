using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CoffeeShop.Tests.UnitTests;

public class UnitTest1
{
    
    [Fact]
    public async void GetAsyncTest()
    {
        var mockCoffeeDbSet = Common.GetQueryableMockDbSet(TestDataCreator.GetTestCoffeeData());
        
        var mockContext = new Mock<CoffeeShopContext>();

        mockContext.Setup(x=>x.Coffees).Returns(mockCoffeeDbSet);

        ICoffeeService coffeeService = new CoffeeService(context:mockContext.Object);

        var data = await coffeeService.GetAsync(1);
        
        Assert.Equal("Latte",data?.Name);
    }
}