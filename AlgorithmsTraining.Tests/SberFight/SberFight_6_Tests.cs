using System;
using System.Collections.Generic;

using AlgorithmsTraining.SberFight;

namespace AlgorithmsTraining.Tests.SberFight
{
    
    public class SberFight_6_Tests : BaseTest
    {
        [Test]
        public void TestLogicalFunctions()
        {
            int a, b, x;

            a = 3;
            b = 1;
            x = ~(~a | b);
            Assert.AreEqual(x, 2);

            a = 6;
            b = 1;
            x = ~(~a | b);
            Assert.AreEqual(x, 6);

            a = 6;
            b = 2;
            x = ~(~a | b);
            Assert.AreEqual(x, 4);

            a = 6;
            b = 1;
            x = ~(~a | b);
            Assert.AreEqual(x, 6);

            a = 5;
            b = 1;
            x = ~(~a | b);
            Assert.AreEqual(x, 4);

            a = 7;
            b = 1;
            x = a ^ b;
            Assert.AreEqual(x, 6);

            a = 7;
            b = 4;
            x = a ^ b;
            Assert.AreEqual(x, 3);
        }

        [Test]
        public void TestResult_1()
        {
            var names = new List<string> { "Kevin", "Jack", "Mark" };
            var statements = new List<string> { "Kevin-is not youngest", "Jack-is oldest", "Mark-is not oldest" };
            var result = SberFight_6.GetResult(names, statements);

            Assert.AreEqual(result[0], "Mark");
            Assert.AreEqual(result[1], "Kevin");
            Assert.AreEqual(result[2], "Jack");
        }

        [Test]
        public void TestResult_2()
        {
            var names = new List<string> { "Kevin", "Jack", "Mark" };
            var statements = new List<string> { "Kevin-is not oldest", "Jack-is not youngest", "Mark-is oldest" };
            var result = SberFight_6.GetResult(names, statements);

            Assert.AreEqual(result[0], "Kevin");
            Assert.AreEqual(result[1], "Jack");
            Assert.AreEqual(result[2], "Mark");
        }

        [Test]
        public void TestResult_3()
        {
            var names = new List<string> { "Kevin", "Jack", "Mark" };
            var statements = new List<string> { "Kevin-is youngest", "Jack-is not youngest", "Jack-is not oldest", "Mark-is oldest" };
            var result = SberFight_6.GetResult(names, statements);

            Assert.AreEqual(result[0], "Kevin");
            Assert.AreEqual(result[1], "Jack");
            Assert.AreEqual(result[2], "Mark");
        }
    }
}
