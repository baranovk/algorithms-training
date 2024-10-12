using System.Collections.Generic;
using System.Linq;

namespace Problems.Strings
{
    /*
     * Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

        A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

        Example:
        Input: "23"
        Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

        2 - [a, b, c]
        3 - [d, e, f]
        4 - [g, h, i]

        "234"
        [adg, adh, adi, aeg, aeh, aei, afg, afh, afi, bdg, bdh, bdi, ...]

            2               3              4
        /   |   \       /   |   \       /  |  \
       a    b    c     d    e    f     g   h   i

           3     
       /   |   \ 
      d    e    f

           4
       /   |   \
      g    h    i

      1: [g, h, i]
      2: [dg, dh, di, eg, eh, ei, fg, fh, fi]
      3: [adg, adh, adi, aeg, aeh, aei, afg, afh, afi, bdg,...]

     */
    public class PhoneNumberLetterCombinations
    {
        private static Dictionary<char, string[]> _numberToLetters;

        static PhoneNumberLetterCombinations()
        {
            _numberToLetters = new Dictionary<char, string[]>
            {
                { '2', new [] { "a", "b", "c" } },
                { '3', new [] { "d", "e", "f" } },
                { '4', new [] { "g", "h", "i" } },
                { '5', new [] { "j", "k", "l" } },
                { '6', new [] { "m", "n", "o" } },
                { '7', new [] { "p", "q", "r", "s" } },
                { '8', new [] { "t", "u", "v" } },
                { '9', new [] { "w", "x", "y", "z" } }
            };
        }

        public static IList<string> LetterCombinations(string digits)
        {
            if(string.IsNullOrEmpty(digits) || 0 == digits.Length) return new List<string>();

            var prev = new List<string>();
            var curr = new List<string>();

            var lastIndex = digits.Length;

            while (0 <= --lastIndex && !_numberToLetters.ContainsKey(digits[lastIndex]));
            if(0 > lastIndex) return new List<string>();

            var d = digits[lastIndex];
            prev.AddRange(_numberToLetters[d]);

            for (var i = --lastIndex; i >= 0; i--)
            {
                d = digits[i];
                if(!_numberToLetters.ContainsKey(d)) continue;

                foreach (var number in _numberToLetters[d])
                {
                    curr.AddRange(prev.Select(s => $"{number}{s}"));
                }

                prev.Clear();
                var tmp = curr;
                curr = prev;
                prev = tmp;
            }

            return prev.Any() ? prev : curr;
        }
    }
}
