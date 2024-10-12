using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.TechRace;
using Problems.Yandex.Algorithms;

namespace Problems.Tests.Yandex.Algorithms
{
    [TestClass]
    public class AlgorithmsTests
    {
        [TestMethod]
        public void TestSolution()
        {
            var (hours, minutes) = MirrorWatch.Solution(2, 45);
            Assert.AreEqual(10, hours);
            Assert.AreEqual(15, minutes);

            (hours, minutes) = MirrorWatch.Solution(6, 0);
            Assert.AreEqual(6, hours);
            Assert.AreEqual(0, minutes);
        }
    }
}
