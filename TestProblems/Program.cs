using System;
using System.Collections.Generic;

namespace TestProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = LengthOfLongestSubstring("1234");
            Console.WriteLine(t);

            Console.ReadLine();
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            if (1 == s.Length) return 1;

            var positions = new Dictionary<char, int>();
            var index = -1;
            var start = 0;
            var end = 0;
            var maxLength = 0;

            while (++index < s.Length)
            {
                if (!positions.ContainsKey(s[index]))
                {
                    positions[s[index]] = index;
                    end = index;
                }

                if (positions.ContainsKey(s[index]) || (index == s.Length - 1))
                {
                    maxLength = Math.Max(maxLength, end - start);

                    if (index < s.Length - 1)
                    {
                        start = positions[s[index]] + 1;
                        positions.Clear();
                        positions[s[start]] = start;
                    }
                }

            }

            return maxLength;
        }
    }
}
