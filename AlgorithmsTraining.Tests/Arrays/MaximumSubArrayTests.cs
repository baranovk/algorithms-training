using System.Collections;
using AlgorithmsTraining.Arrays;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Arrays;

internal class MaximumSubArrayTests
{
    [TestCaseSource(nameof(TestCases))]
    public int Solution_Should_Return_MaxSum(int[] nums)
    {
        return MaximumSubArray.Solution(nums);
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            ReadFromResources("AlgorithmsTraining.Tests.Arrays.Resources.max-sub-arrays-testcase.txt").Split(',').Select(s => int.Parse(s)).ToArray()
        ).Returns(1288333);
        yield return new TestCaseData(new int[] { -2, -1 }).Returns(-1);
        yield return new TestCaseData(new int[] { 3, -2, -3, -3, 1, 3, 0 }).Returns(4);
        yield return new TestCaseData(new int[] { 0, -3, 1, 1 }).Returns(2);
        yield return new TestCaseData(new int[] { -1 }).Returns(-1);
        yield return new TestCaseData(new int[] { -2, 1 }).Returns(1);
        yield return new TestCaseData(new int[] { 5, 4, -1, 7, 8 }).Returns(23);
        yield return new TestCaseData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }).Returns(6);
        yield return new TestCaseData(new int[] { 5, -1, -1, -1, -1 }).Returns(5);
        yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5 }).Returns(15);
        yield return new TestCaseData(new int[] { 5 }).Returns(5);
    }
}
