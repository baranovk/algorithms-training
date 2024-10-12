using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Parentheses
{
    public static class Pairs_1
    {
        /*
         Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

            Example 1:

            Input: n = 3
            Output: ["((()))","(()())","(())()","()(())","()()()"]

            Example 2:

            Input: n = 1
            Output: ["()"]

            1 <= n <= 8
         */

        private static char[] _parenthesis;
        private static Stack<char> _stack;

        public static IList<string> GenerateParenthesis(int n)
        {
            if (1 == n) return new List<string> {"()"};

            _parenthesis = new char[n*2];
            _stack = new Stack<char>();

            var output = new List<string>();

            Step(0, '(', output);
            Step(0, ')', output);

            return output;
        }

        private static void Step(int index, char parenthesis, List<string> output)
        {
            _parenthesis[index] = parenthesis;

            if (index == _parenthesis.Length - 1)
            {
                if (ValidateParenthesis(_parenthesis))
                {
                    output.Add(new string(_parenthesis));
                }

                return;
            }

            Step(index + 1, '(', output);
            Step(index + 1, ')', output);
        }

        private static bool ValidateParenthesis(char[] parenthesis)
        {
            _stack.Clear();

            foreach (var p in parenthesis)
            {
                if (_stack.Any() && '(' == _stack.Peek() && ')' == p)
                {
                    _stack.Pop();
                    continue;
                }

                _stack.Push(p);
            }

            return !_stack.Any();
        }
    }
}
