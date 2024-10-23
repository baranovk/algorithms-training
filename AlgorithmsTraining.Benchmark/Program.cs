using AlgorithmsTraining.Numbers;
using BenchmarkDotNet.Running;

namespace AlgorithmsTraining.Benchmark;

internal class Program
{
    static void Main(string[] args)
    {
        var _ = BenchmarkRunner.Run(
            new Type[] { 
                typeof(NumberOfSmallestUnoccupiedChair), 
                typeof(NumberOfSmallestUnoccupiedChairOptimized), 
            });
    }
}
