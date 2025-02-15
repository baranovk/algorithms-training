﻿using System.Collections.Generic;

using AlgorithmsTraining.SberFight;

namespace AlgorithmsTraining.Tests.SberFight
{
    
    public class SberFight_1_Tests
    {
        [Test]
        public void TestSolution()
        {
            var r = SberFight_1.Solution(new List<string> { "09-13", "12-14" });
            Assert.AreEqual(r, false);

            r = SberFight_1.Solution(new List<string> { "07-09", "10-12", "15-19" });
            Assert.AreEqual(r, true);

            r = SberFight_1.Solution(new List<string> { "07-09" });
            Assert.AreEqual(r, true);
        }
    }
}
