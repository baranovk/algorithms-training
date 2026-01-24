using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays
{
    internal class SurroundedRegionsTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void SurroundedRegions_Tests(char[][] board, char[][] expectedResult)
        {
            SurroundedRegions.Solve(board);
            Assert.That(expectedResult, Is.EqualTo(board));
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                new char[][]
                {
                    ['X','X','X','X'],
                    ['X','O','O','X'],
                    ['X','O','O','X'],
                    ['X','O','X','X']
                },
                new char[][]
                {
                    ['X','X','X','X'],
                    ['X','O','O','X'],
                    ['X','O','O','X'],
                    ['X','O','X','X']
                }
            );

            yield return new TestCaseData(
                new char[][]
                {
                    ['X'],
                },
                new char[][]
                {
                    ['X'],
                }
            );

            yield return new TestCaseData(
                new char[][]
                {
                    ['X','X','X','X'],
                    ['X','O','O','X'],
                    ['X','X','O','X'],
                    ['X','O','X','X']
                },
                new char[][]
                {
                    ['X','X','X','X'],
                    ['X','X','X','X'],
                    ['X','X','X','X'],
                    ['X','O','X','X']
                }
            );

            yield return new TestCaseData(
                new char[][]
                {
                    ['X','X','X','X'],
                    ['X','O','X','X'],
                    ['X','X','O','X'],
                    ['X','O','X','X'],
                    ['X','O','X','X']
                },
                new char[][]
                {
                    ['X','X','X','X'],
                    ['X','X','X','X'],
                    ['X','X','X','X'],
                    ['X','O','X','X'],
                    ['X','O','X','X']
                }
            );

            yield return new TestCaseData(
                new char[][]
                {
                    ['X','O','X'],
                    ['X','O','X'],
                    ['X','O','X']
                },
                new char[][]
                {
                    ['X','O','X'],
                    ['X','O','X'],
                    ['X','O','X']
                }
            );

            yield return new TestCaseData(
                new char[][]
                {
                    ['O','O','O'],
                    ['O','O','O'],
                    ['O','O','O']
                },
                new char[][]
                {
                    ['O','O','O'],
                    ['O','O','O'],
                    ['O','O','O']
                }
            );
        }
    }
}
