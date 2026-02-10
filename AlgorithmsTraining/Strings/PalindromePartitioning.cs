namespace AlgorithmsTraining.Strings
{
    /*
     * 131. Palindrome Partitioning

       Given a string s, partition s such that every of the partition is a . Return all possible palindrome partitioning of s.
       
       Example 1:
       
       Input: s = "aab"
       Output: [["a","a","b"],["aa","b"]]
       
       Example 2:
       
       Input: s = "a"
       Output: [["a"]]
       
       Constraints:
       
         [1] 1 <= s.length <= 16
         [2] s contains only lowercase English letters.

        Runtime
        27 ms
        Beats 23.67%

        Memory
        84.69 MB
        Beats 9.19%
     */
    public static class PalindromePartitioning  // "ccaacabacb"
    {
        private const char PalindromeMark = 'P';

        public static IList<IList<string>> Partition(string s)
        {
            char[,] matrix = new char[s.Length, s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if(IsPalindrome(matrix, i, j, s))
                    {
                        matrix[i, j] = PalindromeMark;
                        TryExpandPalindrome(s, matrix, i, j);
                    }
                }
            }

            var result = new List<IList<string>>();
            PrintMatrix(matrix);
            CollectPartitions(s, matrix, 0, Enumerable.Empty<string>().ToList(), result);
            return result;
        }

        private static void TryExpandPalindrome(string s, char[,] matrix, int i, int j)
        {
            if (i > 0 && j < s.Length - 1 && s[i - 1] == s[j + 1])
            {
                matrix[i - 1, j + 1] = PalindromeMark;
                TryExpandPalindrome(s, matrix, i - 1, j + 1);
            }
        }

        private static bool IsPalindrome(char[,] matrix, int i, int j, string s)
        {
            return i == j || (PalindromeMark == matrix[i, j - 1] && s[i] == s[j]);
        }

        private static void CollectPartitions(string s, char[,] matrix, int position, 
            List<string> prevPartitions, List<IList<string>> accumulator)
        {
            for (int i = position; i < s.Length; i++)
            {
                if (PalindromeMark == matrix[position, i])
                {
                    var nextPartitions = new List<string>();
                    nextPartitions.AddRange(prevPartitions);
                    nextPartitions.Add(s.Substring(position, i - position + 1));

                    if (i < s.Length - 1)
                    {
                        CollectPartitions(s, matrix, i + 1, nextPartitions, accumulator);
                    }
                    else
                    {
                        accumulator.Add(nextPartitions);
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(default == matrix[i, j] ? 'O' : matrix[i, j]);
                    Console.Write('\t');
                }

                Console.Write('\r');
                Console.Write('\n');
            }
        }
    }
}
