using CoffeeShop.BusinessLogic.Common;
using CoffeeShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BusinessLogic.Validation.Common
{
    internal static class CustomRules
    {
        internal static bool StringLengthRule(string str)
        => str?.Length <= Constants.MaxStringLength;

        internal static bool PercentageRule(float number)
            => number >= 0 && number <= 100;

        internal static bool DeliveryWaysRule(DeliveryWays way)
            => way.Equals(DeliveryWays.InPoint)
                ||
               way.Equals(DeliveryWays.InShop);

        internal static bool MaxCapacityRule(int capacity)
            => capacity >= 0 && capacity <= Constants.MaxCapacity;
    }
}
