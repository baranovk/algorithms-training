
using AlgorithmsTraining.Numbers;

namespace AlgorithmsTraining.Tests.Numbers
{
    
    public class DivideTwoIntegersTests
    {
        [Test]
        public void BasicTest()
        {
            var quotient = DivideTwoIntegers.Divide(10, 3);
            Assert.AreEqual(quotient, 3);

            quotient = DivideTwoIntegers.Divide(9, 3);
            Assert.AreEqual(quotient, 3);

            quotient = DivideTwoIntegers.Divide(1, 3);
            Assert.AreEqual(quotient, 0);

            quotient = DivideTwoIntegers.Divide(-100, 3);
            Assert.AreEqual(quotient, -33);

            quotient = DivideTwoIntegers.Divide(-2147483648, -1);
            Assert.AreEqual(quotient, int.MaxValue);
        }

        [Test]
        public void BasicTest_1()
        {
            int r;

            r = DivideTwoIntegers.Divide_1(-2147483648, 2);
            Assert.AreEqual(r, -1073741824);

            r = DivideTwoIntegers.Divide_1(1, 2);
            Assert.AreEqual(r, 0);

            r = DivideTwoIntegers.Divide_1(-2147483648, -1);
            Assert.AreEqual(r, int.MaxValue);

            r = DivideTwoIntegers.Divide_1(-100, 3);
            Assert.AreEqual(r, -33);

            r = DivideTwoIntegers.Divide_1(-10, 3);
            Assert.AreEqual(r, -3);

            r = DivideTwoIntegers.Divide_1(10, 3);
            Assert.AreEqual(r, 3);

            r = DivideTwoIntegers.Divide_1(9, 3);
            Assert.AreEqual(r, 3);

            r = DivideTwoIntegers.Divide_1(8, 8);
            Assert.AreEqual(r, 1);
            
            r = DivideTwoIntegers.Divide_1(8, 2);
            Assert.AreEqual(r, 4);
        }
    }
}
