using AlgorithmsTraining.Strings;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Strings;

internal class GroupAnagramsTests
{
    [Test]
    public void Solution_Should_Return_AnagramGroups()
    {
        var testCase = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
        var result = GroupAnagrams.Solution(testCase);

        Assert.That(result.Count, Is.EqualTo(3));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, new string[] { "bat" })));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, new string[] { "nat", "tan" })));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, new string[] { "ate", "eat", "tea" })));

        testCase = new string[] { "" };
        result = GroupAnagrams.Solution(testCase);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, new string[] { "" })));

        testCase = new string[] { "a" };
        result = GroupAnagrams.Solution(testCase);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, new string[] { "a" })));
    }

    [Test]
    public void TestCalculateKey()
    {
        var t1 = CalculateKey("duh");
        var t2 = CalculateKey("ill");
        Assert.That(t1, Is.Not.EqualTo(t2));
    }

    private static int CalculateKey(string str) 
    {
        var groups = str.GroupBy(_ => _);
        var t0 = groups.Select(g => (100 + (g.Key - 'a')) * g.Count());
        var t1 = t0.Sum();
        return t1;
    }
}
