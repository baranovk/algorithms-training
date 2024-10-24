using System.Text;
using AlgorithmsTraining.Numbers;

namespace AlgorithmsTraining.Tests.Numbers;

public class NumberOfSmallestUnoccupiedChairOptimizedTests
{
    private readonly NumberOfSmallestUnoccupiedChairOptimized _sut = new();

    [Test]
    public void Test_1()
    {
        var times = new int[][] { new[] { 3, 10 }, new[] { 1, 5 }, new[] { 2, 6 } };
        var chair = _sut.SmallestChairOptimized(times, 0);
        Assert.That(chair, Is.EqualTo(2));
    }

    [Test]
    public void Test_2()
    {
        var times = new int[][] { new[] { 1, 4 }, new[] { 2, 3 }, new[] { 4, 6 } };
        var chair = _sut.SmallestChairOptimized(times, 1);
        Assert.That(chair, Is.EqualTo(1));
    }

    [Test]
    public void Test_3()
    {
        var times = new int[][] { new[] { 1, 5 }, new[] { 4, 6 }, new[] { 2, 3 } };
        var chair = _sut.SmallestChairOptimized(times, 2);
        Assert.That(chair, Is.EqualTo(1));
    }

    [Test]
    public void Test_4()
    {
        var times = new int[][] { new[] { 1, 6 }, new[] { 2, 5 }, new[] { 3, 4 }, new[] { 5, 7 } };
        var chair = _sut.SmallestChairOptimized(times, 3);
        Assert.That(chair, Is.EqualTo(1));
    }

    [Test]
    public void Test_5()
    {
        var times = new int[][] { new[] { 1, 6 }, new[] { 2, 4 }, new[] { 3, 5 }, new[] { 5, 7 } };
        var chair = _sut.SmallestChairOptimized(times, 3);
        Assert.That(chair, Is.EqualTo(1));
    }

    [Test]
    public void Test_6()
    {
        var times = new int[][] { new[] { 1, 5 }, new[] { 2, 5 }, new[] { 3, 6 }, new[] { 5, 7 } };
        var chair = _sut.SmallestChairOptimized(times, 3);
        Assert.That(chair, Is.EqualTo(0));
    }

    [Test]
    public void Test_7()
    {
        var times = new int[][] {
            new[] {33889, 98676}, new[] {80071, 89737}, new[] {44118, 52565}, new[] {52992, 84310},
            new[] {78492, 88209}, new[] {21695, 67063}, new[] {84622, 95452}, new[] {98048, 98856},
            new[] {98411, 99433}, new[] {55333, 56548}, new[] {65375, 88566}, new[] {55011, 62821},
            new[] {48548, 48656}, new[] {87396, 94825}, new[] {55273, 81868}, new[] { 75629, 91467 }
        };

        /*
         * { Number: 5, ArrivalTime: 21695, LeavingiTime: 67063}  { Number: 0, ArrivalTime: 33889, LeavingiTime: 98676} 
         * { Number: 2, ArrivalTime: 44118, LeavingiTime: 52565}  { Number: 12, ArrivalTime: 48548, LeavingiTime: 48656} 
         * { Number: 3, ArrivalTime: 52992, LeavingiTime: 84310}  { Number: 11, ArrivalTime: 55011, LeavingiTime: 62821} 
         * { Number: 14, ArrivalTime: 55273, LeavingiTime: 81868} { Number: 9, ArrivalTime: 55333, LeavingiTime: 56548} 
         * { Number: 10, ArrivalTime: 65375, LeavingiTime: 88566} { Number: 15, ArrivalTime: 75629, LeavingiTime: 91467} 
         * { Number: 4, ArrivalTime: 78492, LeavingiTime: 88209}  { Number: 1, ArrivalTime: 80071, LeavingiTime: 89737} 
         * { Number: 6, ArrivalTime: 84622, LeavingiTime: 95452}  { Number: 13, ArrivalTime: 87396, LeavingiTime: 94825} 
         * { Number: 7, ArrivalTime: 98048, LeavingiTime: 98856}  { Number: 8, ArrivalTime: 98411, LeavingiTime: 99433} 
         */

        // { Number: 2, ArrivalTime: 44118, LeavingiTime: 52565}
        var chair = _sut.SmallestChairOptimized(times, 6);
        Assert.That(chair, Is.EqualTo(2));
    }

    [Test]
    public void Test_8()
    {
        var times = new int[][] { 
            new[] { 4, 5 }, new[] { 12, 13 }, new[] { 5, 6 }, new[] { 1, 2 }, new[] { 8, 9 }, new[] { 9, 10 }, 
            new[] { 6, 7 }, new[] { 3, 4 }, new[] { 7, 8 }, new[] { 13, 14 }, new[] { 15, 16 }, new[] { 14, 15 }, 
            new[] { 10, 11 }, new[] { 11, 12 }, new[] { 2, 3 }, new[] { 16, 17 } };

        var chair = _sut.SmallestChairOptimized(times, 15);
        Assert.That(chair, Is.EqualTo(0));
    }
}
