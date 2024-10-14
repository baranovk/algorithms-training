using System.Collections.Generic;

using AlgorithmsTraining.SberFight;

namespace AlgorithmsTraining.Tests.SberFight
{
    
    public class SberFight_2_Tests
    {
        [Test]
        public void TestSolution_1()
        {
            var fences = new List<int> {0, 2, 4, 1, 6, 2};
            var r = SberFight_2.Solution(fences);
            Assert.AreEqual(r, true);
        }

        [Test]
        public void TestSolution_2()
        {
            var fences = new List<int> { 2, -1, 0, 2 };
            var r = SberFight_2.Solution(fences);
            Assert.AreEqual(r, true);
        }


        [Test]
        public void TestSolution_3()
        {
            var fences = new List<int> { 0, 0, 0, 0 };
            var r = SberFight_2.Solution(fences);
            Assert.AreEqual(r, false);
        }

        [Test]
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
