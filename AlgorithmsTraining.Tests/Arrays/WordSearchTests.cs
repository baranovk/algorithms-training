using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class WordSearchTests
{
    [TestCaseSource(nameof(TestCases))]
    public bool WordSearchTests_Tests(char[][] board, string word) => WordSearch.Exist(board, word);

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            [
                new char[][]
                {
                    ['a', 'b'],
                    ['c', 'd']
                },
                "acdb"
            ]
        )
        .Returns(true);

        yield return new TestCaseData(
            [
                new char[][]
                {
                    ['a', 'b']
                },
                "ba"
            ]
        )
        .Returns(true);

        yield return new TestCaseData(
            [
                new char[][]
                {
                    ['a']
                },
                "b"
            ]
        )
        .Returns(false);

        yield return new TestCaseData(
            [
                new char[][] 
                {
                    ['A','B','C','E'],
                    ['S','F','C','S'],
                    ['A','D','E','E']
                }, 
                "ABCCED"
            ]
        )
        .Returns(true);

        yield return new TestCaseData(
            [
                new char[][]
                {
                    ['A','B','C','E'],
                    ['S','F','C','S'],
                    ['A','D','E','E']
                },
                "SEE"
            ]
        )
        .Returns(true);

        yield return new TestCaseData(
            [
                new char[][]
                {
                    ['A','B','C','E'],
                    ['S','F','C','S'],
                    ['A','D','E','E']
                },
                "ABCB"
            ]
        )
        .Returns(false);
    }
}
