using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CityData.Application.Extensions
{
    public static class StringExtension
    {
        public static int GetAndCleanNumbers(this string text)
        {
            Regex regex = new Regex(@"[0-9.]+");
            return int.Parse(regex.Match(text).Value.Trim().Replace(".", ""));
        }

        public static string ChangeSpaceWithDash(this string text)
        {
            return text.Trim().Replace(" ", "-");
        }
    }
}
