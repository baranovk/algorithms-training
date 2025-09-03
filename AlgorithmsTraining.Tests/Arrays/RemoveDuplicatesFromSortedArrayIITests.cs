using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class RemoveDuplicatesFromSortedArrayIITests
{
    [TestCaseSource(nameof(TestCases))]
    public void RemoveDuplicatesFromSortedArrayII_Tests(int[] nums, int[] expectedResult)
    {
        var result = RemoveDuplicatesFromSortedArrayII.RemoveDuplicates(nums);
        Assert.That(result, Is.EqualTo(expectedResult.Length));
        Assert.That(nums.AsSpan(0, result).ToArray(), Is.EquivalentTo(expectedResult));
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            new int[] { 1, 1, 1 },
            new int[] { 1, 1 }
        );

        yield return new TestCaseData(
            new int[] { 1, 2 },
            new int[] { 1, 2 }
        );

        yield return new TestCaseData(
            new int[] { 1, 1, 1, 2, 2, 3 },
            new int[] { 1, 1, 2, 2, 3 }
        );

        yield return new TestCaseData(
            new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 },
            new int[] { 0, 0, 1, 1, 2, 3, 3 }
        );
    }
}
