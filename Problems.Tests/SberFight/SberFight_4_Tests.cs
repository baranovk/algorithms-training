using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.SberFight;

namespace Problems.Tests.SberFight
{
    [TestClass]
    public class SberFight_4_Tests
    {
        [TestMethod]
        public void TestShifts()
        {
            var n = 4;
            n >>= 1;
            Assert.AreEqual(n, 2);

            n = 4;
            n >>= 2;
            Assert.AreEqual(n, 1);

            n = 5;
            n >>= 1;
            Assert.AreEqual(n, 2);

            n = 1;
            n >>= 1;
            Assert.AreEqual(n, 0);
        }

        [TestMethod]
        public void TestSolution_1()
        {
            var arr = new List<int> { 3, 2, 4, 5 };
            var r = SberFight_4.Solution(arr, 9);
            Assert.IsTrue(r);
        }

        [TestMethod]
        public void TestSolution_2()
        {
            var arr = new List<int> { 3, 2, 4, 5 };
            var r = SberFight_4.Solution(arr, 6);
            Assert.IsFalse(r);
        }
    }
}
