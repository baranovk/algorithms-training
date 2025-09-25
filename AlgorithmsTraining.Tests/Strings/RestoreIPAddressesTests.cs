using System.Collections;
using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings;

internal class RestoreIPAddressesTests
{
    [TestCaseSource(nameof(TestCases))]
    public void RestoreIPAddresses_Tests(string s, IList<string> expectedResult)
    {
        var result = RestoreIPAddresses.Solution(s);
        Assert.That(result, Is.EquivalentTo(expectedResult));
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            "25525511135",
            new List<string> { "255.255.11.135", "255.255.111.35" }
        );

        yield return new TestCaseData(
            "0000",
            new List<string> { "0.0.0.0" }
        );

        yield return new TestCaseData(
            "101023",
            new List<string> { "1.0.10.23", "1.0.102.3", "10.1.0.23", "10.10.2.3", "101.0.2.3" }
        );
    }
}
