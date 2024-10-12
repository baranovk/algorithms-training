using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Numbers;

namespace Problems.Tests.Numbers
{
    [TestClass]
    public class ReverseIntegerTests
    {
        [TestMethod]
        public void TestIsDivisibleBy10()
        {
            var num = 10;
            Assert.IsTrue(ReverseInteger.IsDivisibleBy10(num));

            num = 20;
            Assert.IsTrue(ReverseInteger.IsDivisibleBy10(num));

            num = 100;
            Assert.IsTrue(ReverseInteger.IsDivisibleBy10(num));

            num = 500;
            Assert.IsTrue(ReverseInteger.IsDivisibleBy10(num));

            num = 1050;
            Assert.IsTrue(ReverseInteger.IsDivisibleBy10(num));
        }

        [TestMethod]
        public void TestReverseNumber()
        {
            var num = 123;
            var reversed = ReverseInteger.Reverse(num);
            Assert.AreEqual(321, reversed);
        }

        [TestMethod]
        public void TestReverseNumber_1()
        {
            var num = 120;
            var reversed = ReverseInteger.Reverse(num);
            Assert.AreEqual(21, reversed);
        }

        [TestMethod]
        public void TestReverseNegativeNumber()
        {
            var num = -123;
            var reversed = ReverseInteger.Reverse(num);
            Assert.AreEqual(-321, reversed);
        }
    }
}
