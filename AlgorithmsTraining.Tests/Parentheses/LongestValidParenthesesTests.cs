using System.Collections;
using AlgorithmsTraining.Parentheses;

namespace AlgorithmsTraining.Tests.Parentheses
{
    internal class LongestValidParenthesesTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void LongestValidParentheses_Tests(string s, int expectedLength)
        {
            var length = LongestValidParentheses.Solution(s);
            Assert.That(length, Is.EqualTo(expectedLength));
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData("(()", 2);
            yield return new TestCaseData(")()())", 4);
            yield return new TestCaseData("(())()))", 6);
            yield return new TestCaseData("(())(()())))", 10);
            yield return new TestCaseData("(())))(()())))", 6);
        }
    }
}
