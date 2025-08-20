namespace AlgorithmsTraining.Strings;

/*
 * 72. Edit Distance

   Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

   You have the following three operations permitted on a word:
   
      - Insert a character
      - Delete a character
      - Replace a character
   
   Example 1:
   
   Input: word1 = "horse", word2 = "ros"
   Output: 3
   Explanation: 
   horse -> rorse (replace 'h' with 'r')
   rorse -> rose (remove 'r')
   rose -> ros (remove 'e')
   
   Example 2:
   
   Input: word1 = "intention", word2 = "execution"
   Output: 5
   Explanation: 
   intention -> inention (remove 't')
   inention -> enention (replace 'i' with 'e')
   enention -> exention (replace 'n' with 'x')
   exention -> exection (replace 'n' with 'c')
   exection -> execution (insert 'u')

   Constraints:

    [1] 0 <= word1.length, word2.length <= 500
    [2] word1 and word2 consist of lowercase English letters.

    Runtime
    3 ms
    Beats 98.04%

    Memory
    46.59 MB
    Beats 38.24%
 */
public static class EditDistance
{
    public static int MinDistance(string word1, string word2)
    {
        if (0 == word1.Length) { return word2.Length; }
        if (0 == word2.Length) { return word1.Length; }
        if (0 == word1.Length && 0 == word2.Length) { return 0; }

        var distances = new int[word1.Length][];
        for (int i = 0; i < distances.Length; i++) { distances[i] = new int[word2.Length]; }
        distances[0][0] = word1[0] == word2[0] ? 0 : 1;

        for (int x = 1; x < word2.Length; x++)
        {
            // первая строка
            // выбрать минимум:
            // 1. либо вставляем все предшествующие символы и сравниваем текущий символ word2 с нулевым символом word1 (замена или ничего)
            // 2. либо удаляем текущий (+1 операция) 
            distances[0][x] = Math.Min(1 + distances[0][x-1], x + (word2[x] == word1[0] ? 0 : 1));
        }

        for (int y = 1; y < word1.Length; y++)
        {
            // первый столбец
            // выбрать минимум:
            // 1. либо удаляем все предшествующие символы и сравниваем текущий символ word1 с нулевым символом word2 (замена или ничего)
            // 2. либо удаляем текущий (+1 операция) 
            distances[y][0] = Math.Min(1 + distances[y - 1][0], y + (word1[y] == word2[0] ? 0 : 1));
        }

        for(int y = 1; y < word1.Length; y++)
        {
            for (int x = 1; x < word2.Length; x++)
            {
                distances[y][x] = Math.Min(
                    /* ↓ */ distances[y - 1][x] + 1,
                        Math.Min(
                    /* → */ distances[y][x - 1] + 1,
                    /* ↘ */ distances[y - 1][x - 1] + (word1[y] == word2[x] ? 0 : 1))
                    
                );
            }
        }

        return distances[word1.Length-1][word2.Length-1];
    }
}
