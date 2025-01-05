using System.Diagnostics.CodeAnalysis;

namespace AlgorithmsTraining.Strings;

/*
 * 49. Group Anagrams
 * 
 * Given an array of strings strs, group the anagrams together. You can return the answer in any order.

 An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, using all the original letters exactly once.

 Example 1:
 Input: strs = ["eat","tea","tan","ate","nat","bat"]
 Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
 
 Explanation:
 
  - There is no string in strs that can be rearranged to form "bat".
  - The strings "nat" and "tan" are anagrams as they can be rearranged to form each other.
  - The strings "ate", "eat", and "tea" are anagrams as they can be rearranged to form each other.

 Example 2:
 Input: strs = [""]
 Output: [[""]]
 
 Example 3:
 Input: strs = ["a"]
 Output: [["a"]]
 
 Constraints:
 
   1 <= strs.length <= 10^4
   0 <= strs[i].length <= 100
   strs[i] consists of lowercase English letters.

   Runtime
   138ms
   Beats 7.14%

   Memory
   65.56MB
   Beats 97.17%
 */
public static class GroupAnagrams
{
    public static IList<IList<string>> Solution(string[] strs)
        => 1 == strs.Length
            ? new List<IList<string>> { new List<string> { strs[0] } }
            : strs
                .GroupBy(x => x.Length)
                .SelectMany(g => g.GroupBy(_ => _, new AnagramComparer1()))
                .Select(x => x.ToList() as IList<string>)
                .ToList();

    private class AnagramComparer : IEqualityComparer<string>
    {
        private static readonly Dictionary<char, int> xdict = new();
        private static readonly Dictionary<char, int> ydict = new();

        public bool Equals(string? x, string? y)
        {
            if (null == x && null == y) return true;
            if (null != x && null == y) return false;
            if (null == x && null != y) return false;
            if (x!.Length != y!.Length) return false;

            for (var i = 0; i < x!.Length; i++)
            {
                if (!xdict.ContainsKey(x[i]))
                {
                    xdict.Add(x[i], 1);
                }
                else
                {
                    xdict[x[i]]++;
                }
            }

            for (var i = 0; i < y!.Length; i++)
            {
                if (!ydict.ContainsKey(y[i]))
                {
                    ydict.Add(y[i], 1);
                }
                else
                {
                    ydict[y[i]]++;
                }
            }

            var areEqual = true;

            foreach (char key in xdict.Keys)
            {
                if (!ydict.TryGetValue(key, out var count) || count != xdict[key])
                {
                    areEqual = false;
                    break;
                }
            }

            xdict.Clear();
            ydict.Clear();

            return areEqual;
        }

        public int GetHashCode([DisallowNull] string obj) => default;
    }

    private class AnagramComparer1 : IEqualityComparer<string>
    {
        private const int LettersCount = 26;

        public bool Equals(string? x, string? y)
        {
            if (null == x && null == y) return true;
            if (null != x && null == y) return false;
            if (null == x && null != y) return false;
            if (x!.Length != y!.Length) return false;

            Span<int> alphabet = stackalloc int[LettersCount];

            for (int i = 0; i < x!.Length; i++)
            {
                alphabet[x[i] - 'a']++;
                alphabet[y[i] - 'a']--;
            }

            for (int i = 0; i < alphabet.Length; i++)
            {
                if (0 != alphabet[i]) { return false; }
            }

            return true;
        }

        public int GetHashCode([DisallowNull] string obj) => default;
    }
}