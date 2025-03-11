using System.Collections;

namespace AlgorithmsTraining.Tests.Arrays;

internal class IsValidSudokuTests
{
    [TestCaseSource(nameof(TestCases))]
    public void Solution_Should_ValidateSudoku()
    {

    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(3, 7).Returns(28);
        yield return new TestCaseData(1, 2).Returns(1);
        yield return new TestCaseData(1, 3).Returns(1);
        yield return new TestCaseData(2, 2).Returns(2);
        yield return new TestCaseData(2, 3).Returns(3);
        yield return new TestCaseData(3, 2).Returns(3);
        yield return new TestCaseData(3, 7).Returns(28);
    }
}
