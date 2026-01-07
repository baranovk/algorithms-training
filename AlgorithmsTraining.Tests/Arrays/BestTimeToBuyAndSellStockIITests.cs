using System.Collections;
using AlgorithmsTraining.Arrays;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Arrays
{
    internal class BestTimeToBuyAndSellStockIITests
    {
        [TestCaseSource(nameof(TestCases))]
        public int BestTimeToBuyAndSellStockIITests_Tests(int[] prices) => BestTimeToBuyAndSellStockII.MaxProfit(prices);

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                ReadFromResources("AlgorithmsTraining.Tests.Arrays.Resources.best-time-to-buy-and-sell-stock-ii-001.txt")
                .Split(',')
                .Select(s => int.Parse(s))
                .ToArray()
            ).Returns(4);
            yield return new TestCaseData(new int[] { 1, 2, 3 }).Returns(2);
            yield return new TestCaseData(new int[] { 1, 2, 10, 5 }).Returns(9);
            yield return new TestCaseData(new int[] { 5, 4, 3, 2 }).Returns(0);
            yield return new TestCaseData(new int[] { 7, 1, 5, 3, 6, 4 }).Returns(7);
            yield return new TestCaseData(new int[] { 3, 2, 6, 5, 0, 3 }).Returns(7);
        }
    }
}
