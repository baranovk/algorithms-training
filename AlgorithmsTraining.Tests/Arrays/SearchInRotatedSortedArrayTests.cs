using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays
{
    
    public class SearchInRotatedSortedArrayTests
    {
        [Test]
        public void Test_1()
        {
            var nums = new [] {4, 5, 6, 7, 0, 1, 2};
            var target = 0;
            var index = SearchInRotatedSortedArray.Search(nums, target);
            Assert.AreEqual(4, index);
        }

        [Test]
        public void Test_2()
        {
            var nums = new[] { 4, 5, 6, 7, 0, 1, 2 };
            var target = 3;
            var index = SearchInRotatedSortedArray.Search(nums, target);
            Assert.AreEqual(-1, index);
        }

        [Test]
        public void Test_3()
        {
            var nums = new[] { 1 };
            var target = 0;
            var index = SearchInRotatedSortedArray.Search(nums, target);
            Assert.AreEqual(-1, index);

            target = 1;
            index = SearchInRotatedSortedArray.Search(nums, target);
            Assert.AreEqual(0, index);
        }

        [Test]
        public void Test_4()
        {
            var nums = new[] { 1, 3, 5 };
            var target = 5;
            var index = SearchInRotatedSortedArray.Search(nums, target);
            Assert.AreEqual(2, index);
        }
    }
}
