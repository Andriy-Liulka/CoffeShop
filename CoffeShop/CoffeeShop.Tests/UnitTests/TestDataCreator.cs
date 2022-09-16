using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Tests.UnitTests;

internal static class TestDataCreator
{
    internal static List<Coffee> GetTestCoffeeData()
    {
        return new List<Coffee>
        {
            new() { Id = 1, IsMilk = true, Name = "Latte", Provider = "United States", BonusesSize = 0 },
            new() { Id = 2, IsMilk = false, Name = "Americano", Provider = "North USA", BonusesSize = 10 },
            new() { Id = 3, IsMilk = true, Name = "Capuchino", Provider = "Italia", BonusesSize = 6 },
            new() { Id = 4, IsMilk = false, Name = "Ekspresso", Provider = "USA", BonusesSize = 15 },
            new() { Id = 5, IsMilk = true, Name = "Flat-White", Provider = "Australia", BonusesSize = 20 },
            new() { Id = 6, IsMilk = false, Name = "Mokachino", Provider = "USA", BonusesSize = 30 },
            new() { Id = 7, IsMilk = false, Name = "Black coffee", Provider = "Efiopia", BonusesSize = 3 }
        };
    }
}