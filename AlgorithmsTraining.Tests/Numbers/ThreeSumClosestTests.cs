
using AlgorithmsTraining.Numbers;

namespace AlgorithmsTraining.Tests.Numbers
{
    
    public class ThreeSumClosestTests
    {
        [Test]
        public void Test3SumClosest()
        {
            var num = new[] { -1, 2, 1, -4 };
            var target = 1;
            var closestSum = _3SumClosest.ThreeSumClosest(num, target);
            Assert.AreEqual(closestSum, 2);

            num = new[] { 1, 2, 4, 8, 16, 32, 64, 128 };
            target = 82;
            closestSum = _3SumClosest.ThreeSumClosest(num, target);
            Assert.AreEqual(closestSum, 82);

            // 132 - 80 = 52
            // 68 - 80 = (-12)
        }
    }
}
