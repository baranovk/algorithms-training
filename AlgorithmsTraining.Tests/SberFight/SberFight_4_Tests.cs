using System.Collections.Generic;

using AlgorithmsTraining.SberFight;

namespace AlgorithmsTraining.Tests.SberFight
{
    
    public class SberFight_4_Tests
    {
        [Test]
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

        [Test]
        public void TestSolution_1()
        {
            var arr = new List<int> { 3, 2, 4, 5 };
            var r = SberFight_4.Solution(arr, 9);
            Assert.IsTrue(r);
        }

        [Test]
        public void TestSolution_2()
        {
            var arr = new List<int> { 3, 2, 4, 5 };
            var r = SberFight_4.Solution(arr, 6);
            Assert.IsFalse(r);
        }
    }
}
