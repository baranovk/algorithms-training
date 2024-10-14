using System;
using System.Collections.Generic;
using System.Linq;

using AlgorithmsTraining.SberFight;

namespace AlgorithmsTraining.Tests.SberFight 
{
    
    public class SberFight_5_Tests : BaseTest
    {
        [Test]
        public void TestRounding()
        {
            var i = 1d;
            var r = (int)Math.Round((i / 3) * 100);
            Assert.AreEqual(r, 33);
        }

        [Test]
        public void TestSolution_0()
        {
            var stamina = new List<int> { 2, 1 };
            var r = SberFight_5.GetResult(stamina, 2);
            Assert.AreEqual(r[0], 100);
            Assert.AreEqual(r[1], 0);
        }

        [Test]
        public void TestSolution_1()
        {
            var stamina = new List<int> {2, 1, 0, 2};
            var r = SberFight_5.GetResult(stamina, 4);
            Assert.AreEqual(r[0], 33);
            Assert.AreEqual(r[1], 33);
            Assert.AreEqual(r[2], 0);
            Assert.AreEqual(r[3], 33);
        }

        [Test]
        public void TestSolution_2()
        {
            var stamina = new List<int> { 1, 0, 3, 4 };
            var r = SberFight_5.GetResult(stamina, 4);
            Assert.AreEqual(r[0], 17);
            Assert.AreEqual(r[1], 0);
            Assert.AreEqual(r[2], 17);
            Assert.AreEqual(r[3], 67);
        }

        //[Test]
        //public void TestStages_0()
        //{
        //    var stamina = new List<int> { 2, 1, 0, 2 };

        //    var fighters = stamina
        //        .Select((s, i) => new SberFight_5.Fighter { InitialStamina = s, CurrentStamina = s, Index = i })
        //        .ToList();

        //    var stage = new SberFight_5.TournamentStage(fighters.Select(_ => new SberFight_5.FightResult(_)).ToArray());
        //    var nextStages = stage.Run().Select(rs => new SberFight_5.TournamentStage(rs));

        //    Assert.AreEqual(stage.FightSetVariants.Count(), 3);
        //    Assert.IsTrue(stage.FightSetVariants.ContainsFights(new[] {0, 1}, new[] {2, 3}));
        //    Assert.IsTrue(stage.FightSetVariants.ContainsFights(new[] {0, 2}, new[] {1, 3}));
        //    Assert.IsTrue(stage.FightSetVariants.ContainsFights(new[] {0, 3}, new[] {1, 2}));

        //    Assert.IsTrue(nextStages.Any(
        //        ns => ns.PrevStageFights.Any(r => r.HasWinner(0, 1))
        //            && ns.PrevStageFights.Any(r => r.HasWinner(3, 2))
        //        )
        //    );

        //    Assert.IsTrue(nextStages.Any(
        //            ns => ns.PrevStageFights.Any(r => r.HasWinner(0, 2))
        //                  && ns.PrevStageFights.Any(r => r.HasWinner(3, 1))
        //        )
        //    );

        //    Assert.IsTrue(nextStages.Any(
        //            ns => ns.PrevStageFights.Any(r => r.HasWinner(0, 0) && r.HasWinner(3, 0))
        //                  && ns.PrevStageFights.Any(r => r.HasWinner(1, 1))
        //        )
        //    );

        //    Assert.IsTrue(nextStages.All(ns => ns.PrevStageFights.Length.Equals(2)));

        //    var finalResults = new List<SberFight_5.FightResult[]>();

        //    foreach (var ns in nextStages)
        //    {
        //        finalResults.AddRange(ns.Run());
        //    }

        //    Assert.IsTrue(finalResults.Any(rs =>
        //        1 == rs.Length && rs[0].Winners.Count().Equals(1) && rs[0].Winners.First().Index.Equals(3) &&
        //        rs[0].Winners.First().CurrentStamina.Equals(1) && rs[0].Winners.First().WinsCount.Equals(2)));

        //    Assert.IsTrue(finalResults.Any(rs =>
        //        1 == rs.Length && rs[0].Winners.Count().Equals(1) && rs[0].Winners.First().Index.Equals(0) &&
        //        rs[0].Winners.First().CurrentStamina.Equals(1) && rs[0].Winners.First().WinsCount.Equals(2)));

        //    Assert.IsTrue(finalResults.Any(rs =>
        //        2 == rs.Length 
        //        && rs[0].Winners.Count().Equals(1) && rs[0].Winners.First().Index.Equals(1) && rs[0].Winners.First().CurrentStamina.Equals(1) && rs[0].Winners.First().WinsCount.Equals(2)
        //        && rs[1].Winners.Count().Equals(1) && rs[1].Winners.First().Index.Equals(1) && rs[1].Winners.First().CurrentStamina.Equals(1) && rs[1].Winners.First().WinsCount.Equals(2)
        //        )
        //    );

        //    var results = SberFight_5.GetResult(stamina, 4);
        //}
    }

    //public static class TestExtensions
    //{
    //    public static bool ContainsFights(this IEnumerable<SberFight_5.FightSet> fightSets, params int[][] fighterIndexes)
    //    {
    //        var contains = true;

    //        foreach (var indexPair in fighterIndexes)
    //        {
    //            contains &= fightSets.Any(
    //                fs => fs.Any(f => f.Fighter1.Index.Equals(indexPair[0]))
    //                && fs.Any(f => f.Fighter2.Index.Equals(indexPair[1]))
    //            );

    //            if (!contains) return false;
    //        }
            
    //        return true;
    //    }

    //    public static bool HasWinner(this SberFight_5.FightResult result, int index, int stamina)
    //    {
    //        return result.Winners.Any(w => w.Index.Equals(index) && w.CurrentStamina.Equals(stamina));
    //    }
    //}
}
