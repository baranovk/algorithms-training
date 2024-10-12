using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.SberFight;

namespace Problems.Tests.SberFight
{
    [TestClass]
    public class SberFight_3_Test
    {
        [TestMethod]
        public void TestSolution_1()
        {
            var s = "aaa";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void TestSolution_2()
        {
            var s= "aaa bb";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 6);
        }

        [TestMethod]
        public void TestSolution_3()
        {
            var s = "aaa bb c";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 8);
        }

        [TestMethod]
        public void TestSolution_4()
        {
            var s = "aaa bb c";
            var count = SberFight_3.Solution(s, "b");
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void TestSolution_5()
        {
            var s = "dddd aaa bb c";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 8);
        }

        [TestMethod]
        public void TestSolution_6()
        {
            var s = "dddd aaa bbbb c aaa";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 5);
        }

        [TestMethod]
        public void TestSolution_7()
        {
            var s = "dddd aaa bbbb aaa";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void TestSolution_8()
        {
            var s = "dddd aaa bbbb cc aaa eeee";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 11);
        }

        [TestMethod]
        public void TestSolution_9()
        {
            var s = "dddd aaa bbbb cc aaa eeeeeee";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 6);
        }
    }
}
