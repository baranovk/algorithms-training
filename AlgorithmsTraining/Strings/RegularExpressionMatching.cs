namespace AlgorithmsTraining.Strings
{
    /*
     * 10. Regular Expression Matching

     * Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

            '.' Matches any single character.
            '*' Matches zero or more of the preceding element.

        Return a boolean indicating whether the matching covers the entire input string (not partial).
        
        Example 1:
        
        Input: s = "aa", p = "a"
        Output: false
        Explanation: "a" does not match the entire string "aa".
        
        Example 2:
        
        Input: s = "aa", p = "a*"
        Output: true
        Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
        
        Example 3:
        
        Input: s = "ab", p = ".*"
        Output: true
        Explanation: ".*" means "zero or more (*) of any character (.)".

        Constraints:

        [1] 1 <= s.length <= 20
        [2] 1 <= p.length <= 20
        [3] s contains only lowercase English letters.
        [4] p contains only lowercase English letters, '.', and '*'.
        [5] It is guaranteed for each appearance of the character '*', there will be a previous valid character to match

        Runtime
        1122 ms
        Beats 5.34%

        Memory
        42.22 MB
        Beats 68.19%
     */
    public static class RegularExpressionMatching
    {
        public static bool IsMatch(string s, string p) => IsMatchInternal(s.AsSpan(), p.AsSpan());

        private static bool IsMatchInternal(ReadOnlySpan<char> s, ReadOnlySpan<char> p)
        {
            int si = 0, pi = 0; char prev = default;
            
            while (si < s.Length && pi < p.Length)
            {
                switch (p[pi])
                {
                    case '.':
                        prev = '.';
                        si += pi + 1 < p.Length && '*' == p[pi + 1] ? 0 : 1;
                        pi++;
                        continue;
                    case '*':
                        var p0 = p[(pi + 1)..];
                        while (si < s.Length && ('.' == prev || s[si] == prev) && !IsMatchInternal(s[si..], p0)) { si++; }
                        pi++;
                        break;
                    default:
                        if (s[si] == p[pi])
                        { si += pi + 1 < p.Length && '*' == p[pi + 1] ? 0 : 1; pi++; }
                        else if (++pi >= p.Length || p[pi] != '*')
                        { return false; }
                        prev = p[pi - 1];
                        continue;
                }
            }

            if (pi + 1 == p.Length && p[pi] == '*') { return true; }

            while (pi + 1 < p.Length && p[pi + 1] == '*')
            {
                pi += 2;
            }

            return si == s.Length && pi == p.Length;
        }
    }
}
