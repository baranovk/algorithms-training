using System.Collections.Generic;

using AlgorithmsTraining.Interview;

namespace AlgorithmsTraining.Tests.Interview
{
    
    public class AkvelonTests
    {
        [Test]
        public void TestMethod1()
        {
            var a = new List<string> { "tea", "tea", "act" };
            var b = new List<string> { "ate", "toe", "acts" };
            var result = Akvelon.GetMinimumDifference(a, b);
            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[1], 1);
            Assert.AreEqual(result[2], -1);
        }

        [Test]
        public void TestMethod2()
        {
            var a = new List<string> { "ttoab" };
            var b = new List<string> { "tooaa" };
            var result = Akvelon.GetMinimumDifference(a, b);
            Assert.AreEqual(result[0], 2);
        }

        [Test]
        public void TestMethod3()
        {
            var a = new List<string> { "tttoab" };
            var b = new List<string> { "tooaac" };
            var result = Akvelon.GetMinimumDifference(a, b);
            Assert.AreEqual(result[0], 3);
        }
    }
}
