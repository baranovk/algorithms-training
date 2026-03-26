using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays
{
    internal class GasStationTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void GasStation_Tests(int[] gas, int[] cost, int expected)
        {
            var result = GasStation.CanCompleteCircuit(gas, cost);
            Assert.That(result, Is.EqualTo(expected));
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 3, 4, 5, 1, 2 },
                3
            );

            yield return new TestCaseData(
                new int[] { 2, 3, 4 },
                new int[] { 3, 4, 3 },
                -1
            );

            yield return new TestCaseData(
                new int[] { 0, 0, 0, 0, 0, 0, 2 },
                new int[] { 0, 0, 0, 0, 0, 1, 0 },
                6
            );
        }
    }
}
