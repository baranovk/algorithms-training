
using AlgorithmsTraining.TechRace;

namespace AlgorithmsTraining.Tests.TechRace
{
    
    public class TechRace_1_Tests
    {
        [Test]
        public void TestSolution()
        {
            var result = TechRace_1.Solution(4, "12,13,7,29,32,3");
            Assert.AreEqual(result.Count, 4);
        }
    }
}
