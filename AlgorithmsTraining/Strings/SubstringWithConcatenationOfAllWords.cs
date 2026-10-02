namespace AlgorithmsTraining.Strings
{
    /*
     * 30. Substring with Concatenation of All Words

       You are given a string s and an array of strings words. All the strings of words are of the same length.

       A concatenated string is a string that exactly contains all the strings of any permutation of words concatenated.

       For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are
       all concatenated strings. "acdbef" is not a concatenated string because it is not the concatenation of any permutation of words.

       Return an array of the starting indices of all the concatenated substrings in s. You can return the answer in any order.

       Example 1:
       
       Input: s = "barfoothefoobarman", words = ["foo","bar"]
       
       Output: [0,9]
       
       Explanation:
       
       The substring starting at 0 is "barfoo". It is the concatenation of ["bar","foo"] which is a permutation of words.
       The substring starting at 9 is "foobar". It is the concatenation of ["foo","bar"] which is a permutation of words.
       
       Example 2:
       
       Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]
       
       Output: []
       
       Explanation:
       
       There is no concatenated substring.
       
       Example 3:
       
       Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]
       
       Output: [6,9,12]
       
       Explanation:
       
       The substring starting at 6 is "foobarthe". It is the concatenation of ["foo","bar","the"].
       The substring starting at 9 is "barthefoo". It is the concatenation of ["bar","the","foo"].
       The substring starting at 12 is "thefoobar". It is the concatenation of ["the","foo","bar"].
       
       Constraints:
       
         [1] 1 <= s.length <= 10^4
         [2] 1 <= words.length <= 5000
         [3] 1 <= words[i].length <= 30
         [4] s and words[i] consist of lowercase English letters.

         Runtime
         1154 ms
         Beats 10.84%

         Memory
         69.86 MB
         Beats 5.42%
     */
    public static class SubstringWithConcatenationOfAllWords
    {
        public static IList<int> FindSubstring(string s, string[] words)
        {
            var trie = new Trie();
            var indexes = new List<int>();
            Dictionary<string, int> wordCounts = words.Distinct().ToDictionary(w => w, w => 0);

            if (1 == wordCounts.Count)
            { 
                words = [string.Join(string.Empty, words)];
                wordCounts = words.Distinct().ToDictionary(w => w, w => 0);
            }

            List<(int start, int end)> sequence = new(words.Length);

            for (int i = 0; i < words.Length; i++) { trie.Insert(words[i]); }
            
            var offset = 0;

            // aaaaaacccbbba
            while (offset <= s.Length - words.Length * words[0].Length)
            {
                sequence.Clear();

                if (HasSequence(s.AsSpan(offset), offset, trie, sequence, words.Length)
                    && IsValidSequence(s, sequence, words, wordCounts))
                {
                    indexes.Add(sequence[0].start);
                    offset = indexes[^1] + 1;
                }
                else if (0 == sequence.Count)
                {
                    break;
                }
                else
                {
                    offset = sequence[0].start == offset ? offset + 1 : sequence[0].start;
                }
            }

            return indexes;
        }

        private static bool IsValidSequence(
            string s,
            IReadOnlyList<(int start, int end)> substrings,
            string[] words,
            Dictionary<string, int> counters)
        {
            InitCounters(words, counters);
            var zerosCount = 0;
            var span = s.AsSpan();

            for (int i = 0; i < substrings.Count; i++)
            {
                var substring = span.Slice(substrings[i].start, substrings[i].end - substrings[i].start + 1).ToString();
                if (0 == --counters[substring]) { zerosCount++; }
            }

            return zerosCount == counters.Count;
        }

        private static void InitCounters(string[] words, Dictionary<string, int> counters)
        {
            for (int i = 0; i < words.Length; i++)
            {
                counters[words[i]] = 0;
            }

            for (int i = 0 ; i < words.Length; i++)
            {
                counters[words[i]]++;
            }
        }

        private static bool HasSequence(ReadOnlySpan<char> span, int offset, Trie trie, IList<(int start, int end)> sequence, int sequenceLength)
        {
            for (int i = 0, start = 0, length = 0; i < span.Length; i++, start = i, length = 0)
            {
                while (start <= span.Length - trie.MaxPrefixLength && trie.CheckIfStartsWithPrefix(span[start..], out var prefixLength) && length < sequenceLength)
                {
                    length++;
                    sequence.Add((offset + start, offset + start + prefixLength - 1));
                    start += prefixLength;
                }

                if (length == sequenceLength) { return true; } else { sequence.Clear(); }
            }

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
            private int _maxPrefixLength;

            public int MaxPrefixLength => _maxPrefixLength;

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
                _maxPrefixLength = Math.Max(s.Length, _maxPrefixLength);
            }

            public int FirstSequence(string s, int offset, IList<(int start, int end)> sequence, int sequenceLength)
            {
                var current = _root;
                var length = 0;

                var span = s.AsSpan(offset);

                for (var start = 0; start < span.Length && length < sequenceLength; start++)
                {
                    var end = start;

                    while (end < span.Length && length < sequenceLength)
                    {
                        if (!current.Children.TryGetValue(span[end], out var child))
                        {
                            length = 0;
                            sequence.Clear();
                            break;
                        }

                        if (child.IsWord)
                        {
                            length++;
                            sequence.Add((start + offset, end + offset));
                            start = end + 1;
                            current = _root;
                        }
                        else
                        {
                            current = child;
                        }

                        end++;
                    }
                }

                return length;
            }

            public IReadOnlyCollection<(int start, int end)> FindPrefixes(ReadOnlyMemory<char> s)
            {
                var current = _root;
                var list = new LinkedList<(int start, int end)>();

                for (var start = 0; start < s.Length; start++)
                {
                    // aaabccc
                    // aabccc
                    // aaaaaabb words ["aaa", "bb"]
                    // aaa aaabb words ["aaa", "bb"]
                    // a aaa aabb words ["aaa", "bb"]
                    // aa aaa abb words ["aaa", "bb"]
                    // aaa aaa bb words ["aaa", "bb"]
                    var end = start;

                    while (end < s.Length)
                    {
                        if (!current.Children.TryGetValue(s.Span[end], out var child))
                        {
                            current = _root;
                            break;
                        }

                        if (child.IsWord)
                        {
                            list.AddLast((start, end));
                            start = end;
                        }

                        current = child;
                        end++;
                    }
                }

                return list;
            }

            public bool CheckIfStartsWithPrefix(ReadOnlySpan<char> s, out int prefixLength)
            {
                var current = _root;
                prefixLength = default;

                var end = 0;

                while (end < s.Length)
                {
                    if (!current.Children.TryGetValue(s[end], out var child))
                    {
                        return false;
                    }

                    if (child.IsWord)
                    {
                        prefixLength = end + 1;
                        return true;
                    }

                    current = child;
                    end++;
                }

                return false;
            }
        }
    }
}
