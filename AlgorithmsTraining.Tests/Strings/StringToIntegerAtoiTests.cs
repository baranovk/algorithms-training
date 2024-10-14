using System;

using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings
{
    
    public class StringToIntegerAtoiTests
    {
        [Test]
        public void TestSolution()
        {
            var s = "   123";
            var r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, 123);

            s = "";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, 0);

            s = "+";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, 0);

            s = "-";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, 0);

            s = "    0000000000000   ";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, 0);

            s = "-01";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, -1);

            s = " + 0 123";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, 0);

            // "2147483648"
            s = "2147483648";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, 2147483647);

            s = " -   234";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, 0);

            s = "   -123";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, -123);

            s = "-123";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, -123);

            s = "123";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, 123);

            s = "  12345678901";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, int.MaxValue);

            s = "-12345678901";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, int.MinValue);

            s = "  1234asd";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, 1234);

            s = "  asd1234asd";
            r = StringToIntegerAtoi.Convert(s);
            Assert.AreEqual(r, 0);
        }
    }
}
