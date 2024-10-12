using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Combinatorics;

namespace Problems.Tests.Combinatorics
{
    [TestClass]
    public class NextPermutationTests
    {
        [TestMethod]
        public void BasicTest()
        {
            var nums = new[] {1, 2, 3, 4, 5};
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 2);
            Assert.AreEqual(nums[2], 3);
            Assert.AreEqual(nums[3], 5);
            Assert.AreEqual(nums[4], 4);

            nums = new[] { 1, 2, 3, 5, 4 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 2);
            Assert.AreEqual(nums[2], 4);
            Assert.AreEqual(nums[3], 3);
            Assert.AreEqual(nums[4], 5);

            nums = new[] { 1, 2, 4, 3, 5 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 2);
            Assert.AreEqual(nums[2], 4);
            Assert.AreEqual(nums[3], 5);
            Assert.AreEqual(nums[4], 3);

            nums = new[] { 1, 2, 4, 5, 3 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 2);
            Assert.AreEqual(nums[2], 5);
            Assert.AreEqual(nums[3], 3);
            Assert.AreEqual(nums[4], 4);

            nums = new[] { 1, 2, 5, 3, 4 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 2);
            Assert.AreEqual(nums[2], 5);
            Assert.AreEqual(nums[3], 4);
            Assert.AreEqual(nums[4], 3);

            nums = new[] { 1, 2, 5, 4, 3 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 3);
            Assert.AreEqual(nums[2], 2);
            Assert.AreEqual(nums[3], 4);
            Assert.AreEqual(nums[4], 5);

            nums = new[] { 1, 3, 2, 4, 5 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 3);
            Assert.AreEqual(nums[2], 2);
            Assert.AreEqual(nums[3], 5);
            Assert.AreEqual(nums[4], 4);

            nums = new[] { 1, 3, 2, 5, 4 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 3);
            Assert.AreEqual(nums[2], 4);
            Assert.AreEqual(nums[3], 2);
            Assert.AreEqual(nums[4], 5);
        }

        [TestMethod]
        public void SubmitTest()
        {
            var nums = new[] { 1, 2, 3 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 3);
            Assert.AreEqual(nums[2], 2);

            nums = new[] { 3, 2, 1 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 2);
            Assert.AreEqual(nums[2], 3);

            nums = new[] { 1, 1, 5 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 5);
            Assert.AreEqual(nums[2], 1);

            nums = new[] { 1 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);

            nums = new[] { 1, 2, 5, 3, 4 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 2);
            Assert.AreEqual(nums[2], 5);
            Assert.AreEqual(nums[3], 4);
            Assert.AreEqual(nums[4], 3);

            nums = new[] { 1, 2, 5, 4, 3 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 3);
            Assert.AreEqual(nums[2], 2);
            Assert.AreEqual(nums[3], 4);
            Assert.AreEqual(nums[4], 5);

            nums = new[] { 1, 3, 2, 4, 5 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 3);
            Assert.AreEqual(nums[2], 2);
            Assert.AreEqual(nums[3], 5);
            Assert.AreEqual(nums[4], 4);

            nums = new[] { 1, 3, 2, 5, 4 };
            NextPermutation.Find(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 3);
            Assert.AreEqual(nums[2], 4);
            Assert.AreEqual(nums[3], 2);
            Assert.AreEqual(nums[4], 5);
        }
    }
}
