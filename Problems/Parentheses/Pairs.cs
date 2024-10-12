using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Parentheses
{
    public static class Pairs
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

        public static IList<string> GenerateParenthesis(int n)
        {
            if (1 == n) return new List<string> { "()" };

            var output = new Dictionary<string, bool>();
            var parentheses = new List<Parentheses>();

            for (var i = 0; i < n; i++)
            {
                parentheses.Add(new Parentheses());
            }

            var children = parentheses;
            output.Add(FormatParenthesis(parentheses), true);

            do
            {
                var root = children.First();

                do
                {
                    root.Children.Add(children[1]);
                    children.RemoveAt(1);

                    var v = FormatParenthesis(parentheses);

                    output.Add(v, true);

                    v = Reverse(v);
                    if (!output.ContainsKey(v))
                    {
                        output.Add(v, true);
                    }
                }
                while (1 < children.Count);

                children = children.First().Children;
            } 
            while (1 < children.Count);

            return output.Keys.ToList();
        }

        public static IList<string> GenerateParenthesis_2(int n)
        {
            if (1 == n) return new List<string> { "()" };

            Parentheses current;
            var output = new Dictionary<string, bool>();

            var root = current = new Parentheses();

            for (var i = 0; i < n; i++)
            {
                var p = current;
                current.Children.Add(new Parentheses { Parent = p, Index = i + 1 });
                current = current.Children.First();
            }

            output.Add(FormatParenthesis(root.Children), true);

            while (current?.Parent != null)
            {
                current = EmptyBucket(current.Parent, () =>
                {
                    var item = FormatParenthesis(root.Children);

                    if (!output.ContainsKey(item))
                    {
                        output.Add(item, true);
                    }

                    var rItem = Reverse(item);

                    if (!output.ContainsKey(rItem))
                    {
                        output.Add(rItem, true);
                    }
                });
            }

            return output.Keys.ToList();
        }

        private static string FormatParenthesis(IEnumerable<Parentheses> parentheses)
        {
            var sb = new StringBuilder();

            foreach (var p in parentheses)
            {
                sb.Append(p.Format());
            }

            return sb.ToString();
        }

        public static string Reverse(string s)
        {
            var r = s.ToCharArray().Reverse().ToArray();

            for (var i = 0; i < r.Length; i++)
            {
                r[i] = ReverseParenthesis(r[i]);
            }

            return new string(r);
        }

        private static char ReverseParenthesis(char c)
        {
            return '(' == c ? ')' : '(';
        }

        //public static void EmptyBucket(Parentheses root)
        //{
        //    if (null == root.Parent || !root.Children.Any()) return;

        //    var bottom = root;

        //    while (bottom.Children.Any())
        //    {
        //        bottom = bottom.Children.First();
        //    }

        //    var target = root.Parent;

        //    while (root.Children.Any())
        //    {
        //        target.Children.Add(bottom);

        //        bottom = bottom.Parent;
        //        bottom.Children.Clear();

        //        target.Children.Last().Parent = target;
        //        target = target.Children.Last();
        //    }
        //}

        public static Parentheses EmptyBucket(Parentheses source, Action onEmptyStep = null)
        {
            var dest = source.Parent;
            if (null == dest) return null;

            while (source.Children.Any())
            {
                var current = source.Children.Last();
                dest.Children.Add(current);
                current.Parent = dest;
                source.Children.Remove(current);
                dest = current;

                onEmptyStep?.Invoke();
            }

            return dest;
        }
    }

    // ()()()()
    // (())()()     (()())()        (()()())        ((())())        ((()()))        ((( () )))
    // (())(())
    // (()(()))
    // 
    public class Parentheses
    {
        public Parentheses()
        {
            Children = new List<Parentheses>();

        }

        public int Index { get; set; }

        public Parentheses Parent { get; set; }

        public List<Parentheses> Children { get; set; }

        public Parentheses GetGrandParent()
        {
            return Parent?.Parent;
        }

        public string Format(bool childrenOnly = false)
        {
            var queue = new Queue<char>();
            Format(this, queue, childrenOnly);
            return new string(queue.ToArray());
        }

        private void Format(Parentheses current, Queue<char> queue, bool childrenOnly = false)
        {
            if (!childrenOnly)
            {
                queue.Enqueue('(');
            }

            current.Children.ForEach(c => Format(c, queue));

            if (!childrenOnly)
            {
                queue.Enqueue(')');
            }
        }
    }
}
