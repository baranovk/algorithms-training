using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays
{
    internal class TriangleTests
    {
        [TestCaseSource(nameof(TestCases))]
        public int Triangle_Tests(IList<IList<int>> triangle) => Triangle.MinimumTotal(triangle);

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                new List<IList<int>> 
                {
                    new List<int> { 2 }, new List<int> { 3, 4 }, new List<int> { 6, 5, 7 }, new List<int> { 4,1,8,3 }
                }
            ).Returns(11);
        }
    }
}
