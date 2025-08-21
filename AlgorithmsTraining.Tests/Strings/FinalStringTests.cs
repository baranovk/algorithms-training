using System.Collections;
using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings;

internal class FinalStringTests
{
    [TestCaseSource(nameof(TestCases))]
    public string FaultyKeyboard_Tests(string s) => FaultyKeyboard.FinalString(s);

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData("string").Returns("rtsng");
        yield return new TestCaseData("poiinter").Returns("ponter");
        yield return new TestCaseData("viwif").Returns("wvf");
    }
}
