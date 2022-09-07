using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CityData.Application.Extensions
{
    public static class StringExtension
    {
        public static double GetAndCleanNumbers(this string text)
        {
            Regex regex = new Regex(@"[0-9.,]+");
            double cleanedNumber = double.Parse(regex.Match(text).Value.Trim().Replace(".", ""));

            return cleanedNumber;
        }

        public static string ChangeSpaceForDash(this string text)
        {
            return text.Trim().Replace(" ", "-");
        }
    }
}
