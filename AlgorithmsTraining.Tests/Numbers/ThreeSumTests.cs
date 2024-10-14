using System;
using System.CodeDom;
using System.Linq;

using AlgorithmsTraining.Numbers;

namespace AlgorithmsTraining.Tests.Numbers
{
    
    public class ThreeSumTests
    {
        [Test]
        public void TestTwoSum()
        {
            var sum = 2;
            var num = new[] { 1, 4, 1, -2, 5, 1, 0 };
            var sets = _3Sum.TwoSum(num, sum, 0, num.Length - 1).ToList();
            Assert.AreEqual(sets.Count, 2);
            sets.ForEach(s => Assert.AreEqual(sum, s.Sum()));

            sum = 2;
            num = new[] { 1, 1, 1, 1, 1, 1, 1 };
            sets = _3Sum.TwoSum(num, sum, 0, num.Length - 1).ToList();
            Assert.AreEqual(sets.Count, 1);
            sets.ForEach(s => Assert.AreEqual(sum, s.Sum()));

            sum = 3;
            num = new[] { 1, -2, 5, 1, -2, 1, 2, 5, 3, 0 };
            sets = _3Sum.TwoSum(num, sum, 0, num.Length - 1).ToList();
            Assert.AreEqual(sets.Count, 3);
            sets.ForEach(s => Assert.AreEqual(sum, s.Sum()));
        }

        [Test]
        public void TestThreeSum()
        {
            var sum = 3;
            // 1  4  1  -2  5  1  0  => {1, 4, -2 }, {-2, 5, 0}, {1, 1, 1}
            // 1  2  4  2  -2  3  5  0  => { 1, 4, -2 }, { 2, -2, 3 }, { -2, 5, 0 }, { 1, 2, 0 }

            // 1  2  4  2  -2  1  3  5  0  1  => { 1, 4, -2 }, { 2, -2, 3 }, { -2, 5, 0 }, { 1, 2, 0 }
            // { 4, -2, 1 }
            // { 1, -2, 4 }
            // sum = 5
            // 1  3  1
            // 3  4  -2
            var num = new[] { 1, 4, 1, -2, 5, 1, 0 };
            var sets = _3Sum.ThreeSum(num, sum).ToList();
            Assert.AreEqual(sets.Count, 3);
            sets.ForEach(s => Assert.AreEqual(sum, s.Sum()));

            num = new[] { 1, 2, 4, 2, -2, 3, 5, 0 };
            sets = _3Sum.ThreeSum(num, sum).ToList();
            Assert.AreEqual(sets.Count, 4);
            sets.ForEach(s => Assert.AreEqual(sum, s.Sum()));

            num = new[] { 1, 2, 4, 2, -2, 1, 3, 5, 1, 0 };
            sets = _3Sum.ThreeSum(num, sum).ToList();
            Assert.AreEqual(sets.Count, 5);
            sets.ForEach(s => Assert.AreEqual(sum, s.Sum()));

            /*
             Input: [-1,0,1,2,-1,-4]
             Output: [[-1,-1,2],[-1,0,1]]
             Wrong output: [[0,1,-1],[2,-1,-1],[-4,2,2]]
             */
        }
    }
}
