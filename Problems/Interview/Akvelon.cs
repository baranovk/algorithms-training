using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Interview
{
    public class Akvelon
    {
        public static void Method()
        {

        }

        public static List<int> GetMinimumDifference(List<string> a, List<string> b)
        {
            var dictA = new Dictionary<char, int>();
            var dictB = new Dictionary<char, int>();
            var result = new List<int>();

            for (var i = 0; i < a.Count; i++)
            {
                if (a[i].Length != b[i].Length)
                {
                    result.Add(-1);
                    continue;
                }

                SplitStrings(a[i], b[i], dictA, dictB);
                var difference = 0;

                foreach (var character in dictA.Keys.Union(dictB.Keys))
                {
                    difference += Math.Abs((dictA.ContainsKey(character) ? dictA[character] : 0) -
                                           (dictB.ContainsKey(character) ? dictB[character] : 0));
                }

                result.Add(difference / 2);
            }

            return result;
        }

        private static void SplitStrings(string s1, string s2, Dictionary<char, int> dictA, Dictionary<char, int> dictB)
        {
            if (s1.Length != s2.Length) return;

            dictA.Clear();
            dictB.Clear();

            foreach (var t in s1)
            {
                if (dictA.ContainsKey(t))
                {
                    dictA[t]++;
                }
                else
                {
                    dictA.Add(t, 1);
                }
            }

            foreach (var t in s2)
            {
                if (dictB.ContainsKey(t))
                {
                    dictB[t]++;
                }
                else
                {
                    dictB.Add(t, 1);
                }
            }
        }
    }
}
