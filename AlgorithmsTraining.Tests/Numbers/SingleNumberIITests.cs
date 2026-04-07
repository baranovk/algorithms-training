using System.Collections;
using AlgorithmsTraining.Numbers;

namespace AlgorithmsTraining.Tests.Numbers
{
    internal class SingleNumberIITests
    {
        [TestCaseSource(nameof(TestCases))]
        public void SingleNumberII_Tests(int[] nums, int expected)
        {
            var result = SingleNumberII.SingleNumber(nums);
            Assert.That(result, Is.EqualTo(expected));
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                new int[] { 2, 2, 3, 2 },
                3
            );

            yield return new TestCaseData(
                new int[] { 0, 1, 0, 1, 0, 1, 99 },
                99
            );
        }
    }
}
