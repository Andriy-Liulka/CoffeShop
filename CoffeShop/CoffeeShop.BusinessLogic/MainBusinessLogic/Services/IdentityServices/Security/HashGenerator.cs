using System.Security.Cryptography;
using System.Text;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.IdentityServices.Security;

public class HashGenerator
{
    internal string GenerateHash(string str)
    {
        var hashStr = new StringBuilder();

        using (SHA256 hash = SHA256.Create())
        {
            var primaryHash = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(str));
                foreach (byte b in result)
                    primaryHash.Append(b.ToString());
            }

            var numberResult = System.Numerics.BigInteger.Parse(primaryHash.ToString());

            numberResult = numberResult >> 25000;
            numberResult = numberResult | 0x50A406693459C;
            numberResult = numberResult ^ 0x50A406F7567C369F;
            numberResult = numberResult << 60;
            numberResult = numberResult | 0x9D73C58F921;

            byte[] result1 = hash.ComputeHash(Encoding.UTF8.GetBytes(numberResult.ToString()));
            foreach (byte b in result1)
                hashStr.Append(b.ToString("x2"));
        }

        return hashStr.ToString();
    }
}