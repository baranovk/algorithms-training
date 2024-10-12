using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.SberFight;

namespace Problems.Tests.SberFight
{
    [TestClass]
    public class SberFight_2_Tests
    {
        [TestMethod]
        public void TestSolution_1()
        {
            var fences = new List<int> {0, 2, 4, 1, 6, 2};
            var r = SberFight_2.Solution(fences);
            Assert.AreEqual(r, true);
        }

        [TestMethod]
        public void TestSolution_2()
        {
            var fences = new List<int> { 2, -1, 0, 2 };
            var r = SberFight_2.Solution(fences);
            Assert.AreEqual(r, true);
        }


        [TestMethod]
        public void TestSolution_3()
        {
            var fences = new List<int> { 0, 0, 0, 0 };
            var r = SberFight_2.Solution(fences);
            Assert.AreEqual(r, false);
        }

        [TestMethod]
        public void TestSolution_4()
        {
            var fences = new List<int>();

            for (var i = 0; i < 100; i++)
            {
                
            }

            var r = SberFight_2.Solution(fences);
            Assert.AreEqual(r, false);
        }
    }
}
