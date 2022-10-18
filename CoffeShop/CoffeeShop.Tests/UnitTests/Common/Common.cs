using Microsoft.EntityFrameworkCore;
using MockQueryable.FakeItEasy;
using Moq;

namespace CoffeeShop.Tests.UnitTests.Common;

internal static class Common
{
    internal static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
    {
        var queryable = sourceList.AsQueryable();

        var dbSet = new Mock<DbSet<T>>();

        dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
        dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
        dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

        dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>(s => sourceList.Add(s));

        return dbSet.Object;
    }


    internal static DbSet<T> GetQueryableMockDbSetAsync<T>(List<T> sourceList) where T : class
        => sourceList.AsQueryable().BuildMockDbSet();


    internal static DbSet<T> GetQueryableMockDbSetAsyncCompleteImpl<T>(List<T> sourceList) where T : class
    {
        var queryable = TestDataCreator.GetTestCoffeeData().AsQueryable().BuildMock();
        var dbSet = new Mock<DbSet<T>>();

        dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
        dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
        dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

        return dbSet.Object;
    }
}