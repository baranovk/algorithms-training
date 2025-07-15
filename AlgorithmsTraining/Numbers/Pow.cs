using System.Collections.Concurrent;
using System.Threading;

namespace AlgorithmsTraining.Numbers;

/*
 * 50. Pow(x, n)
 * 
 * Implement pow(x, n), which calculates x raised to the power n (i.e., x^n).

   Example 1:
   
   Input: x = 2.00000, n = 10
   Output: 1024.00000
   
   Example 2:
   
   Input: x = 2.10000, n = 3
   Output: 9.26100
   
   Example 3:
   
   Input: x = 2.00000, n = -2
   Output: 0.25000
   Explanation: 2^(-2) = 1/2^2 = 1/4 = 0.25

   Constraints:

    1. -100.0 < x < 100.0
    
    2. -2^31 <= n <= 2^31-1
    
    3. n is an integer.
    
    4. Either x is not zero or n > 0.
    -10^4 <= x^n <= 10^4

    Runtime
    0ms
    Beats 100.00%

    Memory
    29.06MB
    Beats 91.88%
 */
public static class Pow
{
    public static double Solution(double x, int n)
    {
        if (0 == n) return 1;
        if (1 == n) return x;
        if (-1 == n) return 1 / x;

        var oddPowAccumulator = 1d;
        double accumulator = x;
        long pow = Math.Abs((long)n);

        do
        {
            if (1 == (pow & 1))
            {
                pow--;
                oddPowAccumulator *= accumulator;
            }

            accumulator *= accumulator;
        }
        while (1 < (pow = pow >> 1));

        return (double.IsInfinity(oddPowAccumulator) ? 1 : 0 < n ? oddPowAccumulator : 1 / oddPowAccumulator) 
            * (0 < n ? accumulator : (1 / accumulator));
    }
}
