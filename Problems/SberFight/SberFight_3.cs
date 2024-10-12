using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.SberFight
{
    public class SberFight_3
    {
        /*
         * Дана строка s, она содержит подстроки c одинаковыми символами, подстроки разделены пробелом.

        Вы можете поэтапно заменять пробелы в строке на любые символы.

        Если между разными последовательностями не окажется пробела, то подстрока с бóльшим количеством символов заменит остальные подстроки. 
        Например, строка "aaabb" становится "aaaaa".

    Создайте максимально крупную подстроку заданного символа. Гарантируется, что одинакового количества символов в результате замен у двух подстрок быть не может.

        Ввод:

        s - строка символов, все последовательности разделены пробелом, 1<=length(s)<=100, s[i]=a..z
        symbol - заданный символ, length(symbol)=1
        Вывод:

        Integer - количество одинаковых подряд идущих заданных символов

        Пример:

        s = "aaa bbb"
        symbol = "a"
        GetResult(s, symbol) = 7
         */
        public static int Solution(string s, string symbol)
        {
            var maxLength = 0;
            var substrings = s.Split(' ').Select(_ => new Substring(_.Substring(0, 1), _.Length)).ToList();

            var lengths = new int[substrings.Count, substrings.Count];

            for (var i = 0; i < substrings.Count; i++)
            {
                lengths[i, i] = substrings[i].Symbol.Equals(symbol) ? substrings[i].Length : 0;
                maxLength = Math.Max(lengths[i, i], maxLength);
            }

            for (var diagonal = 1; diagonal < substrings.Count; diagonal++)
            {
                var j = 0;

                for (var i = diagonal; i < substrings.Count; i++, j++)
                {
                    var symbolPrevSubstringLength = lengths[i - 1, j];
                    var lastSubstringIndex = Math.Max(i, j);

                    lengths[i, j] = substrings[lastSubstringIndex].Symbol.Equals(symbol)
                        ? substrings[lastSubstringIndex].Length
                        : 0;

                    if (0 < symbolPrevSubstringLength && symbolPrevSubstringLength >= substrings[lastSubstringIndex].Length)
                    {
                        lengths[i, j] = symbolPrevSubstringLength + 1 + substrings[lastSubstringIndex].Length;
                    }
                    else if (0 == symbolPrevSubstringLength && substrings[lastSubstringIndex].Symbol.Equals(symbol))
                    {
                        lengths[i, j] = substrings[lastSubstringIndex].Length > substrings[lastSubstringIndex - 1].Length
                            ? substrings[lastSubstringIndex].Length + 1 + substrings[lastSubstringIndex - 1].Length
                            : substrings[lastSubstringIndex].Length;
                    }
                    else
                    {
                        lengths[i, j] = 0;
                    }

                    maxLength = Math.Max(lengths[i, j], maxLength);
                }
            }

            DebugArray(s, lengths);
            return maxLength;
        }

        private static void DebugArray(string s, int[,] arr)
        {
            Debug.WriteLine(s);
            Debug.WriteLine("");

            var sb = new StringBuilder();

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    sb.Append($"{arr[i, j]}\t");
                }

                Debug.WriteLine(sb.ToString());
                sb.Clear();
            }
        }

        private struct Substring
        {
            public Substring(string symbol, int length)
            {
                Symbol = symbol;
                Length = length;
            }

            public string Symbol;

            public int Length;
        }
    }
}
