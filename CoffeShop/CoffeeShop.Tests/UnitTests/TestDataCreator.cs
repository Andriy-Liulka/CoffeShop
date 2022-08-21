using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Tests.UnitTests;

internal static class TestDataCreator
{
    internal static List<Coffee> GetTestCoffeeData() => new List<Coffee> 
    {            
        new Coffee{Id = 1, IsMilk = true, Name = "Latte", Provider = "United States", BonusesSize = 0},
        new Coffee{Id = 2, IsMilk = false, Name = "Americano", Provider = "North USA", BonusesSize = 10},
        new Coffee{Id = 3, IsMilk = true, Name = "Capuchino", Provider = "Italia", BonusesSize = 6},
        new Coffee{Id = 4, IsMilk = false, Name = "Ekspresso", Provider = "USA", BonusesSize = 15},
        new Coffee{Id = 5, IsMilk = true, Name = "Flat-White", Provider = "Australia", BonusesSize = 20},
        new Coffee{Id = 6, IsMilk = false, Name = "Mokachino", Provider = "USA", BonusesSize = 30},
        new Coffee{Id = 7, IsMilk = false, Name = "Black coffee", Provider = "Efiopia", BonusesSize = 3} 
    };


}