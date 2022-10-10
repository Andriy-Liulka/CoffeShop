using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BusinessLogic.Exceptions
{
    internal class InvalidValidatorException : BusinessLogicException
    {
        public InvalidValidatorException(string errorMessage = "This validator doesn't exest !")
            :base(errorMessage)
        {

        }
    }
}
