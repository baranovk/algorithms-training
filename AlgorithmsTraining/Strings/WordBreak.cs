namespace AlgorithmsTraining.Strings
{
    /*
     * 139. Word Break
     * 
     * Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated
     * sequence of one or more dictionary words.

       Note that the same word in the dictionary may be reused multiple times in the segmentation.
       
       Example 1:
       
       Input: s = "leetcode", wordDict = ["leet","code"]
       Output: true
       Explanation: Return true because "leetcode" can be segmented as "leet code".
       
       Example 2:
       
       Input: s = "applepenapple", wordDict = ["apple","pen"]
       Output: true
       Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
       Note that you are allowed to reuse a dictionary word.
       
       Example 3:
       
       Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
       Output: false
       
       Constraints:
       
         [1] 1 <= s.length <= 300
         [2] 1 <= wordDict.length <= 1000
         [3] 1 <= wordDict[i].length <= 20
         [4] s and wordDict[i] consist of only lowercase English letters.
         [5] All the strings of wordDict are unique.

        Runtime
        6 ms
        Beats 58.10%

        Memory
        45.64 MB
        Beats 56.63%
     */
    public static class WordBreak
    {
        public static bool Solution(string s, IList<string> wordDict)
        {
            var trie = new Trie();

            for (int i = 0; i < wordDict.Count; i++) { trie.Insert(wordDict[i]); }

            return CanBreak(s.AsMemory(), trie, 0, []);
        }

        private static bool CanBreak(ReadOnlyMemory<char> s, Trie trie, int index, HashSet<int> failMemo)
        {
            foreach (var prefixLength in trie.FindPrefixes(s))
            {
                if (!failMemo.Contains(index + prefixLength) 
                    && (prefixLength == s.Length
                        || CanBreak(s[prefixLength..], trie, index + prefixLength, failMemo)))
                { return true; }
            }

            failMemo.Add(index);
            return false;
        }

        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; } = [];

            public bool IsWord { get; set; }
        }

        private class Trie
        {
            private readonly TrieNode _root = new();

            public void Insert(string s)
            {
                var current = _root;

                for (var i = 0; i < s.Length; i++)
                {
                    if (!current.Children.TryGetValue(s[i], out var child))
                    {
                        current.Children.Add(s[i], child = new TrieNode());
                    }

                    current = child;
                }

                current.IsWord = true;
            }

            public IEnumerable<int> FindPrefixes(ReadOnlyMemory<char> s)
            {
                var current = _root;
                var stack = new Stack<int>();

                for (var i = 0; i < s.Length; i++)
                {
                    if (!current.Children.TryGetValue(s.Span[i], out var child))
                    {
                        break;
                    }

                    if (child.IsWord)
                    {
                        stack.Push(i + 1);
                        //yield return i + 1;
                    }

                    current = child;
                }

                while (stack.Count > 0)
                {
                    yield return stack.Pop();
                }
            }
        }
    }
}
