namespace AlgorithmsTraining.Numbers;

/*
 * 89. Gray Code
   
   An n-bit gray code sequence is a sequence of 2^n integers where:

    Every integer is in the inclusive range [0, 2^n - 1],
    The first integer is 0,
    An integer appears no more than once in the sequence,
    The binary representation of every pair of adjacent integers differs by exactly one bit, and
    The binary representation of the first and last integers differs by exactly one bit.

  Given an integer n, return any valid n-bit gray code sequence.

  Example 1:

  Input: n = 2
  Output: [0,1,3,2]
  
  Explanation:
  
  The binary representation of [0,1,3,2] is [00,01,11,10].
  - 00 and 01 differ by one bit
  - 01 and 11 differ by one bit
  - 11 and 10 differ by one bit
  - 10 and 00 differ by one bit
  [0,2,3,1] is also a valid gray code sequence, whose binary representation is [00,10,11,01].
  - 00 and 10 differ by one bit
  - 10 and 11 differ by one bit
  - 11 and 01 differ by one bit
  - 01 and 00 differ by one bit
  
  Example 2:
  
  Input: n = 1
  Output: [0,1]

  Constraints:

   [1] 1 <= n <= 16

   Runtime
   2 ms
   Beats 48.86%

   Memory
   56.16 MB
   Beats 46.59%

0   0   0   0   [0]
0   0   0   1   [1]
0   0   1   1   [3]
0   0   1   0   [2]
0   1   1   0   [6]
0   1   1   1   [7]
0   1   0   1   [5]
0   1   0   0   [4]
1   1   0   0   [12]
1   1   0   1   [13]
1   1   1   1   [15]
1   1   1   0   [14]
1   0   1   0   [10]
1   0   1   1   [11]
1   0   0   1   [9]
1   0   0   0   [8]

================================
0   0   0   [0]
0   0   1   [1]
0   1   1   [3]
0   1   0   [2]
1   1   0   [6]
1   1   1   [7]
1   0   1   [5]
1   0   0   [4]

 */
public static class GrayCode
{
    public static IList<int> Solution(int n)
    {
        var result = new List<int>();
        Descent(0, n - 1, result, false);
        return result;
    }

    private static void Descent(int num, int n, IList<int> sequences, bool revert)
    {
        SetBit(ref num, n, revert ? BitValue.One : BitValue.Zero);
        if (0 == n) { sequences.Add(num); } else { Descent(num, n - 1, sequences, false); }

        SetBit(ref num, n, revert ? BitValue.Zero : BitValue.One);
        if (0 == n) { sequences.Add(num); } else { Descent(num, n - 1, sequences, true); }
    }

    private static void SetBit(ref int num, int pos, BitValue value)
    {
        if (value == BitValue.One)
        {
            num |= (1 << pos);
        }
        else
        {
            num &= ~(1 << pos);
        }
    }

    private enum BitValue { Zero, One }
}
