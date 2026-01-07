using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays
{
    internal class LongestConsecutiveSequenceTests
    {
        [TestCaseSource(nameof(TestCases))]
        public int LongestConsecutiveSequence_Tests(int[] nums) => LongestConsecutiveSequence.LongestConsecutive(nums);

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(new int[] { 100, 4, 200, 1, 3, 2 }).Returns(4);
            yield return new TestCaseData(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }).Returns(9);
            //yield return new TestCaseData(new int[] { (int)Math.Pow(-10, 9), 0, (int)Math.Pow(10, 9) }).Returns(1);
        }
    }
}
