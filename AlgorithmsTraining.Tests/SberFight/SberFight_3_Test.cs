
using AlgorithmsTraining.SberFight;

namespace AlgorithmsTraining.Tests.SberFight
{
    
    public class SberFight_3_Test
    {
        [Test]
        public void TestSolution_1()
        {
            var s = "aaa";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 3);
        }

        [Test]
        public void TestSolution_2()
        {
            var s= "aaa bb";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 6);
        }

        [Test]
        public void TestSolution_3()
        {
            var s = "aaa bb c";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 8);
        }

        [Test]
        public void TestSolution_4()
        {
            var s = "aaa bb c";
            var count = SberFight_3.Solution(s, "b");
            Assert.AreEqual(count, 4);
        }

        [Test]
        public void TestSolution_5()
        {
            var s = "dddd aaa bb c";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 8);
        }

        [Test]
        public void TestSolution_6()
        {
            var s = "dddd aaa bbbb c aaa";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 5);
        }

        [Test]
        public void TestSolution_7()
        {
            var s = "dddd aaa bbbb aaa";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 3);
        }

        [Test]
        public void TestSolution_8()
        {
            var s = "dddd aaa bbbb cc aaa eeee";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 11);
        }

        [Test]
        public void TestSolution_9()
        {
            var s = "dddd aaa bbbb cc aaa eeeeeee";
            var count = SberFight_3.Solution(s, "a");
            Assert.AreEqual(count, 6);
        }
    }
}
