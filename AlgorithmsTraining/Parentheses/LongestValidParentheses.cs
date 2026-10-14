namespace AlgorithmsTraining.Parentheses
{
    /*
     * 32. Longest Valid Parentheses
        
       Given a string containing just the characters '(' and ')', return the length of the longest valid (well-formed) parentheses substring.

       Example 1:
       
       Input: s = "(()"
       Output: 2
       Explanation: The longest valid parentheses substring is "()".
       
       Example 2:
       
       Input: s = ")()())"
       Output: 4
       Explanation: The longest valid parentheses substring is "()()".
       
       Example 3:
       
       Input: s = ""
       Output: 0
       
       Constraints:
       
           [1] 0 <= s.length <= 3 * 104
           [2] s[i] is '(', or ')'.

       Runtime
       16ms
       Beats 8.24%

       Memory
       42.73 MB
       Beats 56.15%
     */
    public static class LongestValidParentheses
    {
        private record struct Parentheses(int From, int Length);

        public static int Solution(string s)
        {
            if (string.IsNullOrEmpty(s)) { return 0; }

            var maxLength = 0;

            var parentheses = new LinkedList<Parentheses>();

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == '(' && s[i + 1] == ')') { parentheses.AddLast(new Parentheses(i, 2)); i++; maxLength = 2; }
            }

            if (0 == parentheses.Count) { return 0; }

            bool updated;

            do 
            {
                updated = false;
                var currentNode = parentheses.First;

                do
                {
                    if (IsExpanded(currentNode, s) || IsMerged(parentheses, currentNode))
                    { 
                        updated = true; 
                        maxLength = Math.Max(currentNode.Value.Length, maxLength);
                    }
                }
                while ((currentNode = currentNode.Next) != null);
            } 
            while (updated);

            return maxLength;
        }

        private static bool IsExpanded(LinkedListNode<Parentheses> current, string s)
        {
            var from = current.Value.From;
            var length = current.Value.Length;

            while (0 <= from - 1 && s[from - 1] == '('
                && from + length < s.Length && s[from + length] == ')')
            {
                from--;
                length += 2;
            }

            if (from != current.Value.From)
            {
                current.Value = new Parentheses(from, length);
                return true;
            }

            return false;
        }

        private static bool IsMerged(LinkedList<Parentheses> parentheses, LinkedListNode<Parentheses> current)
        {
            var length = current.Value.Length;

            while (null != current.Next && (current.Value.From + current.Value.Length) == current.Next.Value.From)
            {
                current.Value = new Parentheses(current.Value.From, current.Value.Length + current.Next.Value.Length);
                parentheses.Remove(current.Next);
            }

            return length != current.Value.Length;
        }
    }
}
