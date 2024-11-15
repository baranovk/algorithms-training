using System.Data;
using System.Runtime.CompilerServices;

namespace AlgorithmsTraining.Numbers;

public static class CountAndSay
{
    /*
     * https://leetcode.com/problems/count-and-say/submissions/1449440908/
     * The count-and-say sequence is a sequence of digit strings defined by the recursive formula:

        countAndSay(1) = "1"
        countAndSay(n) is the run-length encoding of countAndSay(n - 1).

        Run-length encoding (RLE) is a string compression method that works by replacing consecutive identical characters (repeated 2 or more times) with the concatenation of the character and the number marking the count of the characters (length of the run). For example, to compress the string "3322251" we replace "33" with "23", replace "222" with "32", replace "5" with "15" and replace "1" with "11". Thus the compressed string becomes "23321511".

        Given a positive integer n, return the nth element of the count-and-say sequence.

        Example 1:

        Input: n = 4

        Output: "1211"

        Explanation:

        countAndSay(1) = "1"
        countAndSay(2) = RLE of "1" = "11"
        countAndSay(3) = RLE of "11" = "21"
        countAndSay(4) = RLE of "21" = "1211"

        Example 2:

        Input: n = 1

        Output: "1"

        Explanation:

        This is the base case.

        Constraints:
        1 <= n <= 30
     */

    private const int ProcessingBufferLength = 1_610_612_736;
    //private const int ProcessingBufferLength = 10;

    /*
     * Runtime
        1ms
        Beats100.00%

        Memory
        39.61MB
        Beats99.12%
     */
    public static string Solution_1(int n)
    {
        return CountAndSayImpl(n);
    }

    private static string CountAndSayImpl(int n)
    {
        if (1 == n) return "1";
        return Rle(CountAndSayImpl(n - 1));
    }

    /*
     * Runtime
       17ms
       Beats47.37%

       Memory
       40.17MB
       Beats98.43%
     */
    public static string Solution_2(int n)
    {
        if (1 == n) { return "1"; }

        int processingBase = default, rleIndex = ProcessingBufferLength, step = 1;
        var buffer = new char[ProcessingBufferLength];

        buffer[processingBase] = '1';
        var prevRleLength = 1;

        for (
            var i = 1;
            i < n; 
            i++, 
            step *= -1,
            processingBase = 0 < step ? 0 : ProcessingBufferLength - 1,
            rleIndex = 0 < step ? ProcessingBufferLength : -1)
        {
            int charCount = 1, processed = 1;
            char memory = buffer[processingBase];
            buffer[processingBase + prevRleLength * step] = '\0';

            for (var j = processingBase + step; processed <= prevRleLength; j += step)
            {                
                processed++;

                if (memory == buffer[j])
                {
                    charCount++;
                    continue;
                }

                rleIndex = InsertNumber(charCount, buffer, rleIndex + step * (-1), step);
                buffer[rleIndex += step * (-1)] = memory;
                memory = buffer[j];
                charCount = 1;
            }

            prevRleLength = Math.Abs(rleIndex - (0 == processingBase ? buffer.Length - 1 : 0)) + 1;
        }

        if (0 == processingBase) 
        { 
            return new string(new Span<char>(buffer).Slice(processingBase, prevRleLength)); 
        }
        else
        {
            var reversed = new Span<char>(buffer, processingBase - prevRleLength + 1, prevRleLength);
            reversed.Reverse();
            return new string(reversed);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int InsertNumber(int number, Span<char> arr, int @base, int step)
    {
        int reminder, index = @base - step;

        do
        {
            reminder = number % 10;
            arr[index += step] = (char)('0' + reminder);
            number /= 10;
        } 
        while (0 < number);

        for (int i = Math.Min(@base, index), j = Math.Max(@base, index); i < j; i++, j--) 
        {
            (arr[j], arr[i]) = (arr[i], arr[j]);
        }

        return index;
    }

    public static string Rle(string s)
    {
        Span<char> source = stackalloc char[s.Length+1];
        s.AsSpan().CopyTo(source);
        
        Span<char> rle = stackalloc char[s.Length*2];

        var rleIndex = -1;
        var memory = s[0];
        var count = 1;

        for (var i = 1; i < source.Length; i++) 
        {
            if (memory != source[i])
            {
                //rle[++rleIndex] = (char)('0' + count);
                rleIndex = InsertNumber(count, rle, ++rleIndex, 1);
                rle[++rleIndex] = memory;
                memory = source[i];
                count = 1;
            }
            else { count++; }
        }

        return new string(rle[..(rleIndex + 1)]);
    }
}
