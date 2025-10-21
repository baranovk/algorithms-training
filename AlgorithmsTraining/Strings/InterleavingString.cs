namespace AlgorithmsTraining.Strings;

/*
 * 97. Interleaving String
 * 
   Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1 and s2.
   
   An interleaving of two strings s and t is a configuration where s and t are divided into n and m
   
   respectively, such that:
   
       s = s1 + s2 + ... + sn
       t = t1 + t2 + ... + tm
       |n - m| <= 1
       The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3 + s3 + ...
   
   Note: a + b is the concatenation of strings a and b.
    
   
   Example 1:

   Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
   Output: true
   Explanation: One way to obtain s3 is:
   Split s1 into s1 = "aa" + "bc" + "c", and s2 into s2 = "dbbc" + "a".
   Interleaving the two splits, we get "aa" + "dbbc" + "bc" + "a" + "c" = "aadbbcbcac".
   Since s3 can be obtained by interleaving s1 and s2, we return true.
   
   Example 2:
   
   Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
   Output: false
   Explanation: Notice how it is impossible to interleave s2 with any other string to obtain s3.
   
   Example 3:
   
   Input: s1 = "", s2 = "", s3 = ""
   Output: true
   
   Constraints:
   
     [1] 0 <= s1.length, s2.length <= 100
     [2] 0 <= s3.length <= 200
     [3] s1, s2, and s3 consist of lowercase English letters.

     Runtime
     60 ms
     Beats 70.54%

     Memory
     41.58 MB
     Beats 66.81%
 */
public static class InterleavingString
{
    public static bool IsInterleave(string s1, string s2, string s3)
    {
        if (string.Empty == s1 && string.Empty == s2 && string.Empty == s3) { return true; }
        if (string.Empty == s1 && string.Empty == s2) { return false; }
        if (string.Empty == s3) { return false; }
        if (string.Empty == s1) { return s2 == s3; }
        if (string.Empty == s2) { return s1 == s3; }
        if (2 > s1.Length && 2 > s2.Length && 2 > s3.Length) { return false; }
        if ((s1.Length + s2.Length) != s3.Length) { return false; }
        return IsInterleaveInternal(s1, s2, s3) || IsInterleaveInternal(s2, s1, s3); 
    }

    private static bool IsInterleaveInternal(string s1, string s2, string s3)
    {
        if (s1[0] != s3[0]) { return false; }

        var prevRow = new int[s2.Length + 1];
        var currentRow = new int[s2.Length + 1];

        prevRow[0] = 1;

        for (var i = 1; i < prevRow.Length; i++) { prevRow[i] = (1 == prevRow[i - 1]) && (s3[i] == s2[i - 1]) ? 1 : 0; }

        for (var i = 1; i < s1.Length; i++)
        {
            currentRow[0] = 1 == prevRow[0] && s3[i] == s1[i] ? 1 : 0;

            for (var j = 1; j < currentRow.Length; j++)
            {
                currentRow[j] = 
                    // from left
                    1 == currentRow[j - 1] && s3[i + j] == s2[j - 1]
                    // OR from top
                    || 1 == prevRow[j] && s3[i + j] == s1[i]
                    ? 1 : 0;
            }

            (prevRow, currentRow) = (currentRow, prevRow);
        }

        return 1 == prevRow[^1];
    }
}
