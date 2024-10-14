using System;

using AlgorithmsTraining.Numbers;

namespace AlgorithmsTraining.Tests.Numbers
{
    
    public class IntegerToRomanTests
    {
        [Test]
        public void Test_1()
        {
            var n = 5;
            var s = IntegerToRoman.IntToRoman(n);
            Assert.AreEqual(s, "V");

            n = 10;
            s = IntegerToRoman.IntToRoman(n);
            Assert.AreEqual(s, "X");

            n = 15;
            s = IntegerToRoman.IntToRoman(n);
            Assert.AreEqual(s, "XV");

            n = 25;
            s = IntegerToRoman.IntToRoman(n);
            Assert.AreEqual(s, "XXV");

            n = 24;
            s = IntegerToRoman.IntToRoman(n);
            Assert.AreEqual(s, "XXIV");
        }

        [Test]
        public void Test_2()
        {
            var n = 350;
            var s = IntegerToRoman.IntToRoman(n);
            Assert.AreEqual(s, "CCCL");

            n = 340;
            s = IntegerToRoman.IntToRoman(n);
            Assert.AreEqual(s, "CCCXL");

            n = 346;
            s = IntegerToRoman.IntToRoman(n);
            Assert.AreEqual(s, "CCCXLVI");

            n = 25;
            s = IntegerToRoman.IntToRoman(n);
            Assert.AreEqual(s, "XXV");

            n = 24;
            s = IntegerToRoman.IntToRoman(n);
            Assert.AreEqual(s, "XXIV");
        }
    }
}
