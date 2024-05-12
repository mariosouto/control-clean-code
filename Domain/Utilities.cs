using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Utilities
    {
        public static bool NumberOfDecimalsGreatherThan(double number, int decimals)
        {
            string value = Convert.ToString(number);
            String currentDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string[] words = value.Split(currentDecimalSeparator[0]);
            if (words.Length > 1)
            {
                int n = Convert.ToInt32(words[1]);
                int digits = 0;
                while (n > 0)
                {
                    n = n / 10;
                    digits++;
                }
                if (digits > decimals)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
