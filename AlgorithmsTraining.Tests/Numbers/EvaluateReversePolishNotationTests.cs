using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsTraining.Numbers;

namespace AlgorithmsTraining.Tests.Numbers
{
    internal class EvaluateReversePolishNotationTests
    {
        [TestCaseSource(nameof(TestCases))]
        public int EvaluateReversePolishNotation_Tests(string[] tokens) => EvaluateReversePolishNotation.EvalRPN(tokens);

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData([new string[] { "2", "1", "+", "3", "*" }]).Returns(9);
            yield return new TestCaseData([new string[] { "4", "13", "5", "/", "+" }]).Returns(6);
            yield return new TestCaseData([new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }]).Returns(22);
        }
    }
}
