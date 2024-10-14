using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using AlgorithmsTraining.Parentheses;

namespace AlgorithmsTraining.Tests.Parentheses
{
    
    public class ParenthesesTests
    {
        [Test]
        public void TestOne()
        {
            var parenthesis = Pairs.GenerateParenthesis(1);
            Assert.AreEqual(parenthesis.First(), "()");
        }

        [Test]
        public void TestTwo()
        {
            var parenthesis = Pairs.GenerateParenthesis_2(2);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()()")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(())")), null);
            Assert.AreEqual(parenthesis.Count, 2);
        }

        [Test]
        public void TestThree()
        {
            var parenthesis = Pairs.GenerateParenthesis_2(3);
            /*
             ()()()     (())()      ()(())      (()())      ((()))

            children: ()()() 
            root: [()]()()

            children:[(())]()
            root: [(())]

            children:[(()())]
            root: [(()())]

            children:()()
            root: ()

            children:()
            root: (())
             */
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()()()")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(())()")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()(())")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(()())")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("((()))")), null);
            Assert.AreEqual(parenthesis.Count, 5);
        }

        [Test]
        public void TestFour()
        {
            var parenthesis = Pairs.GenerateParenthesis_2(4);
            /*
             * (((())))

                (( ()() ))

                (( () ) () )

                ( () (()) )

                ( () () () )

                ( () () ) ()

                ( () ) ( () )

                () ( ( () ) )
                () ( () () )
                () ( () ) ()
                () () ( () )
                () () () () 

             */
            /*
             ()()()()     (())(())
             (())()()   ()()(())
             (()())()   ()(()())
             (()()())
             ((())())   (()(()))
             ((()()))
             (((())))

            children: ()()() 
            root: [()]()()

            children:[(())]()
            root: [(())]

            children:[(()())]
            root: [(()())]

            children:()()
            root: ()

            children:()
            root: (())
             */
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(((())))")), null);

            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("((()()))")), null);

            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("((())())")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(()(()))")), null);

            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(()()())")), null);

            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(()())()")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()(()())")), null);

            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(())(())")), null);

            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()((()))")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("((()))()")), null);

            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()(()())")), null);

            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()(())()")), null);

            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()()(())")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(())()()")), null);

            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()()()()")), null);

            //Assert.AreEqual(parenthesis.Count, 5);
        }

        [Test]
        public void TestFive()
        {
            var parenthesis = Pairs.GenerateParenthesis(3);
            /*
             ()()()()()   (())(())()    ()(())(())      (())()(()) 
             (())()()()   ()()()(())
             (()())()()   ()(()())
             (()()())
             ((())())   (()(()))
             ((()()))
             (((())))

            children: ()()() 
            root: [()]()()

            children:[(())]()
            root: [(())]

            children:[(()())]
            root: [(()())]

            children:()()
            root: ()

            children:()
            root: (())
             */
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()()()")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(())()")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()(())")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(()())")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("((()))")), null);
            Assert.AreEqual(parenthesis.Count, 5);
        }

        [Test]
        public void TestReverse()
        {
            var s = "(()())()";
            var r = Pairs.Reverse(s);
            Assert.AreEqual(r, "()(()())");
        }

        [Test]
        public void TestEmptyBucket()
        {
            var root = new AlgorithmsTraining.Parentheses.Parentheses(); 
            GenerateChain(root, 1);
            Pairs.EmptyBucket(root.Children.First());
            Assert.AreEqual(root.Format(), "(())");

            root.Children.Clear();
            root = GenerateChain(root, 2);
            Pairs.EmptyBucket(root.Children.First());
            Assert.AreEqual(root.Format(), "(()())");

            root.Children.Clear();
            root = GenerateChain(root, 3);
            Pairs.EmptyBucket(root.Children.First());
            Assert.AreEqual(root.Format(), "(()(()))");

            root.Children.Clear();
            root = GenerateChain(root, 4);
            Pairs.EmptyBucket(root.Children.First());
            Assert.AreEqual(root.Format(), "(()((())))");
        }

        [Test]
        public void TestDifference()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var file1 = File.ReadAllText(Path.Combine(basePath, "expected.txt"));
            var file2 = File.ReadAllText(Path.Combine(basePath, "output.txt"));

            var strings1 = file1.Split('\r', '\n').Where(_ => !string.IsNullOrEmpty(_));
            var strings2 = file2.Split('\r', '\n').Where(_ => !string.IsNullOrEmpty(_));

            var dict1 = strings1.ToDictionary(_ => _, _ => _);
            var dict2 = strings2.ToDictionary(_ => _, _ => _);

            var diff = dict1.Keys.Count > dict2.Keys.Count
                ? dict1.Keys.Except(dict2.Keys)
                : dict2.Keys.Except(dict1.Keys);

            if (diff.Any())
            {
                var sb = new StringBuilder();

                foreach (var v in diff)
                {
                    sb.Append($"{v}\r\n");
                }

                var diffFilePath = Path.Combine(basePath, "diff.txt");

                if (File.Exists(diffFilePath))
                {
                    File.Delete(diffFilePath);
                }

                File.WriteAllText(diffFilePath, sb.ToString());
            }
        }

        private AlgorithmsTraining.Parentheses.Parentheses GenerateChain(AlgorithmsTraining.Parentheses.Parentheses root, int n)
        {
            var current = root;

            for (var i = 0; i < n; i++)
            {
                current.Children.Add(new AlgorithmsTraining.Parentheses.Parentheses { Index = i + 1, Parent = current });
                current = current.Children.First();
            }

            return root;
        }
    }
}
