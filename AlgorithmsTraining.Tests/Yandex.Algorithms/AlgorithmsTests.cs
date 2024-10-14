
using AlgorithmsTraining.TechRace;
using AlgorithmsTraining.Yandex.Algorithms;

namespace AlgorithmsTraining.Tests.Yandex.Algorithms
{
    
    public class AlgorithmsTests
    {
        [Test]
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
