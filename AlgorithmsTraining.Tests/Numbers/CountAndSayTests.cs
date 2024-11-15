using AlgorithmsTraining.Numbers;

namespace AlgorithmsTraining.Tests.Numbers;

internal class CountAndSayTests
{
    [Test]
    [TestCase("11", "21")]
    [TestCase("21", "1211")]
    [TestCase("1211", "111221")]
    [TestCase("111221", "312211")]
    [TestCase("312211", "13112221")]
    public void Rle_Should_GenerateCorrectSequence(string source, string target)
    {
        var result = CountAndSay.Rle(source);
        Assert.That(result, Is.EqualTo(target));
    }

    [Test]
    [TestCase(1, "1")]
    [TestCase(4, "1211")]
    public void RecursiveSolution_Should_GenerateCorrectSequence(int n, string sequence)
    {
        var result = CountAndSay.Solution_1(n);
        Assert.That(result, Is.EqualTo(sequence));
    }

    [Test]
    [TestCase(1, "1")]
    [TestCase(2, "11")]
    [TestCase(3, "21")]
    [TestCase(4, "1211")]
    [TestCase(5, "111221")]
    [TestCase(6, "312211")]
    [TestCase(7, "13112221")]
    public void IterativeSolution_Should_GenerateCorrectSequence(int n, string sequence)
    {
        var result = CountAndSay.Solution_2(n);
        Assert.That(result, Is.EqualTo(sequence));
    }

    [Test]
    [TestCase(5)]
    [TestCase(12)]
    [TestCase(125)]
    [TestCase(3234)]
    public void InsertNumber_Should_InsertNumberWithAnyOrder(int n)
    {
        var str = n.ToString();
        var arr = new char[str.Length];

        CountAndSay.InsertNumber(n, arr, 0, 1);
        Assert.That(new string(arr), Is.EqualTo(str));

        CountAndSay.InsertNumber(n, arr, arr.Length - 1, -1);
        Assert.That(new string(arr), Is.EqualTo(str.Reverse()));
    }
}
