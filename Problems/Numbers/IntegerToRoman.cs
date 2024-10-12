using System.Collections.Generic;
using System.Text;

namespace Problems.Numbers
{
    public static class IntegerToRoman
    {
        /*
         Symbol       Value
            I             1
            V             5
            X             10
            L             50
            C             100
            D             500
            M             1000

            
            I can be placed before V (5) and X (10) to make 4 and 9. 
            X can be placed before L (50) and C (100) to make 40 and 90. 
            C can be placed before D (500) and M (1000) to make 400 and 900.

            Given an integer, convert it to a roman numeral. Input is guaranteed to be within the range from 1 to 3999.
         */
        public static string IntToRoman(int num)
        {
            var delitel = 1000;
            var ostatok = num;
            var tmp = new string[9];
            var result = new StringBuilder();

            var bases = new Dictionary<int, string>
            {
                { 1, "I" },
                { 10, "X" },
                { 100, "C" },
                { 1000, "M" }
            };
            var symbols = new Dictionary<int, string>
            {
                { 4, "IV" },
                { 5, "V" },
                { 9, "IX" },
                { 40, "XL" },
                { 50, "L" },
                { 90, "XC" },
                { 400, "CD" },
                { 500, "D" },
                { 900, "CM" },
            };

            // n = 25

            while (true)
            {
                if (ostatok >= delitel)
                {
                    // 25 / 10 = 2
                    var chastnoe = ostatok / delitel;
                    var index = -1;

                    for (var i = 1; i <= chastnoe; i++)
                    {
                        if (symbols.ContainsKey(i * delitel))
                        {
                            index = 0;
                            tmp[index] = symbols[i * delitel];
                        }
                        else
                        {
                            tmp[++index] = bases[delitel];
                        }
                    }

                    ostatok = ostatok % delitel;

                    for (var i = 0; i <= index; i++)
                    {
                        result.Append(tmp[i]);
                    }
                }

                if (0 == ostatok) break;
                if (1 == delitel) break;
                delitel /= 10;
            }

            return result.ToString();
        }
    }
}
