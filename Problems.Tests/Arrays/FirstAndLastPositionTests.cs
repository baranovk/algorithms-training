using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Arrays;

namespace Problems.Tests.Arrays
{
    [TestClass]
    public class FirstAndLastPositionTests
    {
        [TestMethod]
        public void Test_1()
        {
            var nums = new int[0];
            var target = 0;
            var result = FirstAndLastPosition.SearchRange(nums, target);
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(-1, result[1]);
        }

        [TestMethod]
        public void Test_2()
        {
            var nums = new [] { 5, 7, 7, 8, 8, 10 };
            var target = 8;
            var result = FirstAndLastPosition.SearchRange(nums, target);
            Assert.AreEqual(3, result[0]);
            Assert.AreEqual(4, result[1]);
        }

        [TestMethod]
        public void Test_3()
        {
            var nums = new[] { 5, 7, 7, 8, 8, 10 };
            var target = 6;
            var result = FirstAndLastPosition.SearchRange(nums, target);
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(-1, result[1]);
        }

        [TestMethod]
        public void Test_4()
        {
            var nums = new[] { 7, 7 };
            var target = 7;
            var result = FirstAndLastPosition.SearchRange(nums, target);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(1, result[1]);
        }
    }
}
