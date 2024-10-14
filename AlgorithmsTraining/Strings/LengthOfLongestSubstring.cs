using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTraining.Strings
{
    public class LengthOfLongestSubstring
    {
        public static int GetLengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            if (1 == s.Length) return 1;
            
            var start = 0;
            var end = -1;
            var maxLength = 0;
            var positions = new Dictionary<char, int>();

            // a a a
            // 0 1 2
            while (++end < s.Length)
            {
                if (positions.ContainsKey(s[end]))
                {
                    maxLength = Math.Max(maxLength, end - start);
                    var lastPos = positions[s[end]];

                    for (var i = start; i <= lastPos; i++)
                    {
                        positions.Remove(s[i]);
                    }

                    start = lastPos + 1;

                    if (0 == positions.Count && start < end)
                    {
                        positions.Add(s[start], start);
                    }
                }
                else if (end == s.Length - 1)
                {
                    maxLength = Math.Max(maxLength, end - start + 1);
                    return maxLength;
                }
                    
                positions.Add(s[end], end);
            }

            return maxLength;
        }
    }
}
