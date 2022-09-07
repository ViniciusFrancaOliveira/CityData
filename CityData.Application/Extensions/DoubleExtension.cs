using System;
using System.Collections.Generic;
using System.Text;

namespace CityData.Application.Extensions
{
    public static class DoubleExtension
    {
        public static bool IsInteger(this double number)
        {
            return number % 1 == 0;
        }
    }
}
