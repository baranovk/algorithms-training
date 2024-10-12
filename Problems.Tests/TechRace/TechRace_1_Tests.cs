using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.TechRace;

namespace Problems.Tests.TechRace
{
    [TestClass]
    public class TechRace_1_Tests
    {
        [TestMethod]
        public void TestSolution()
        {
            var result = TechRace_1.Solution(4, "12,13,7,29,32,3");
            Assert.AreEqual(result.Count, 4);
        }
    }
}
