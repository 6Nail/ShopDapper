using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.UI
{
    public static class StringExtensions
    {
        public static string ExtractOnlyText(this string text)
        {
            var result = string.Empty;
            foreach (var character in text)
            {
                if (char.IsDigit(character))
                {
                    continue;
                }
                result += character;
            }


            return result;
        }
    }
}
