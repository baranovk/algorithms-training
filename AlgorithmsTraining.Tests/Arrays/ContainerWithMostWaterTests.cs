using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays
{
    public class ContainerWithMostWaterTests
    {
        [Test]
        public void TestMaxWater_3_Heights()
        {
            var heights = new [] {3, 1, 3};
            var maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 6);

            heights = new[] { 3, 1, 4 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 6);

            heights = new[] { 4, 1, 3 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 6);

            heights = new[] { 1, 4, 3 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 3);

            heights = new[] { 2, 2, 2 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 4);

            heights = new[] { 2, 3, 2 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 4);

            heights = new[] { 2, 3, 4 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 4);

            heights = new[] { 4, 3, 2 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 4);
        }

        [Test]
        public void TestMaxWater_4_Heights()
        {
            var heights = new[] { 1, 2, 3, 4 };
            var maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 4);

            heights = new[] { 2, 4, 4, 1 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 4);

            heights = new[] { 4, 2, 3, 4 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 12);
        }

        [Test]
        public void TestMaxWater_5_Heights()
        {
            var heights = new[] { 1, 2, 3, 4, 5 };
            var maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 6);

            heights = new[] { 3, 2, 15, 15, 5 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 15);

            heights = new[] { 2, 3, 3, 4, 1 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 6);

            heights = new[] { 5, 4, 3, 2, 1 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 6);

            heights = new[] { 5, 4, 4, 2, 1 };
            maxArea = ContainerWithMostWater.MaxArea(heights);
            Assert.AreEqual(maxArea, 8);
        }
    }
}
