using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings;

public class MultiplyStringsTests
{
    [Test]
    [TestCase("11", "22", "242")]
    [TestCase("13", "25", "325")]
    [TestCase("653", "125", "81625")]
    [TestCase("456", "123", "56088")]
    [TestCase("123", "456", "56088")]
    [TestCase("0", "9999", "0")]
    [TestCase("123456789", "987654321", "121932631112635269")]
    public void Solution_Should_MultiplyStrings(string num1, string num2, string multiply)
    {
        var @result = MultiplyStrings.Solution(num1, num2);
        Assert.That(@result, Is.EqualTo(multiply));
    }

    [Test]
    [TestCase("11", "22", "242")]
    [TestCase("13", "25", "325")]
    [TestCase("653", "125", "81625")]
    [TestCase("456", "123", "56088")]
    [TestCase("123", "456", "56088")]
    [TestCase("0", "9999", "0")]
    [TestCase("123456789", "987654321", "121932631112635269")]
    public void Solution_1_Should_MultiplyStrings(string num1, string num2, string multiply)
    {
        var @result = MultiplyStrings.Solution_1(num1, num2);
        Assert.That(@result, Is.EqualTo(multiply));
    }
}
