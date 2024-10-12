namespace Problems.Strings
{
    public static class LongestPalindromicSubstring
    {
        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (1 == s.Length) return s;

            var start = 0;
            var end = 0;
            var maxLength = 0;

            for (var i = 0; i < s.Length - 1; i++)
            {
                if (maxLength >= s.Length - i) break;

                for (var j = s.Length - 1; j >= i + 1; j--)
                {
                    if (IsPalindrom(s, i, j))
                    {
                        if (maxLength < j - i + 1)
                        {
                            start = i;
                            end = j;
                            maxLength = end - start + 1;
                        }

                        break;
                    }
                }
            }

            return start == end ? s.Substring(start, 1) : s.Substring(start, end - start + 1);
        }

        public static string LongestPalindrome_1(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (1 == s.Length) return s;
            // a a a a
            var maxLength = 0;
            int maxStart = 0, maxEnd = 0, start, end;

            for (var i = 1; i < s.Length; i++)
            {
                start = i - 1;
                end = i + 1;
                if (SpreadAroundCenter(s, ref start, ref end) && maxLength < end - start + 1)
                {
                    maxLength = end - start + 1;
                    maxStart = start;
                    maxEnd = end;
                }

                start = i - 1;
                end = i;
                if (SpreadAroundCenter(s, ref start, ref end) && maxLength < end - start + 1)
                {
                    maxLength = end - start + 1;
                    maxStart = start;
                    maxEnd = end;
                }
            }

            return maxStart == maxEnd ? s.Substring(maxStart, 1) : s.Substring(maxStart, maxEnd - maxStart + 1);
        }

        public static bool SpreadAroundCenter(string s, ref int left, ref int right)
        {
            var isPalindrome = false;
            int l = left, r = right;

            while (0 <= l && r < s.Length && s[l] == s[r])
            {
                left = l;
                right = r;
                l--;
                r++;
                isPalindrome = true;
            }

            return isPalindrome;
        }

        public static bool IsPalindrom(string s, int start, int end)
        {
            // a a a a
            if (start >= end) return false;
            if (1 == end - start + 1) return true;

            while (start < end)
            {
                if (s[start] != s[end])
                    return false;

                start++;
                end--;
            }

            return true;
        }
    }
}
