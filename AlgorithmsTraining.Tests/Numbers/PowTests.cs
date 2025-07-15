using System.Collections;
using AlgorithmsTraining.Numbers;

namespace AlgorithmsTraining.Tests.Numbers;

internal class PowTests
{
    private const double Delta = 0.00001;

    [TestCase(2, -2_147_483_648, 0.00000)]
    [TestCase(2, -2_00_000_000, 0.00000)]
    [TestCase(2, 3, 8)]
    [TestCase(2, 4, 16)]
    [TestCase(2, 10, 1024)]
    [TestCase(2, 13, 8192)]
    [TestCase(2, 2, 4)]
    [TestCase(2, -2, 0.25)]
    [TestCase(2.1, 3, 9.26100d)]
    [TestCase(10, 3, 1000)]
    [TestCase(-2, 2, 4)]
    [TestCase(34.00515, -3, 2.543114507074558E-05)] // 2.543114507074558E-05
    [TestCase(8.95371, -1, 0.11169)]
    public void Solution_Should_CountCalculatePow(double x, int n, double expectedResult)
    {
        var result = Pow.Solution(x, n);
        Assert.That(result, Is.EqualTo(expectedResult).Within(Delta));
    }
}
