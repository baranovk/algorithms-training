
using AlgorithmsTraining.Parentheses;
using System.Linq;

namespace AlgorithmsTraining.Tests.Parentheses
{
    
    public class ParenthesesTests_1
    {
        [Test]
        public void TestOne()
        {
            var parenthesis = Pairs_1.GenerateParenthesis(1);
            Assert.AreEqual(parenthesis.First(), "()");
        }

        [Test]
        public void TestTwo()
        {
            var parenthesis = Pairs_1.GenerateParenthesis(2);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()()")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(())")), null);
            Assert.AreEqual(parenthesis.Count, 2);
        }

        [Test]
        public void TestThree()
        {
            var parenthesis = Pairs_1.GenerateParenthesis(3);
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
    }
}
