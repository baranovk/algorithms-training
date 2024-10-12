using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Parentheses;
using System.Linq;

namespace Problems.Tests.Parentheses
{
    [TestClass]
    public class ParenthesesTests_1
    {
        [TestMethod]
        public void TestOne()
        {
            var parenthesis = Pairs_1.GenerateParenthesis(1);
            Assert.AreEqual(parenthesis.First(), "()");
        }

        [TestMethod]
        public void TestTwo()
        {
            var parenthesis = Pairs_1.GenerateParenthesis(2);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("()()")), null);
            Assert.AreNotEqual(parenthesis.SingleOrDefault(p => p.Equals("(())")), null);
            Assert.AreEqual(parenthesis.Count, 2);
        }

        [TestMethod]
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
