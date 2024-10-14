using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AlgorithmsTraining.Numbers
{
    /*
     * https://leetcode.com/problems/reverse-integer/
     * Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed
     * 32-bit integer range [-231, 231 - 1], then return 0.
     *
     * Example 1:

       Input: x = 123
       Output: 321

       Example 2:

       Input: x = -123
       Output: -321

       Example 3:

       Input: x = 120
       Output: 21
     */
    public class ReverseInteger
    {
        public static int Reverse(int x)
        {
            switch (x)
            {
                case 0:
                case int.MinValue:
                    return 0;
            }

            var result = 0;
            var sign = 0 > x ? -1 : 1;
            var bytes = Encoding.ASCII.GetBytes((sign * x).ToString());
            ReverseArray(bytes);

            var numberStr = Encoding.ASCII.GetString(bytes).TrimStart('0');

            try
            {
                result = Convert.ToInt32(numberStr);
            }
            catch (OverflowException)
            {
                return result;
            }

            return sign * result;
        }

        private static void ReverseArray(byte[] arr)
        {
            var i = 0;
            var j = arr.Length - 1;

            while (i < j)
            {
                var t = arr[i];
                arr[i] = arr[j];
                arr[j] = t;

                i++;
                j--;
            }
        }

        // https://www.geeksforgeeks.org/decimal-representation-given-binary-string-divisible-10-not/
        public static bool IsDivisibleBy10(int x)
        {
            // if odd number - return false
            if (1 == (1 & x))
                return false;

            var mask = 0x40000000; // 0100 0000 0000 0000 0000 0000 0000 0000
            var posFromRight = 30;
            var sum = 0;

            while (posFromRight >= 0)
            {
                if (mask == (mask & x))
                {
                    // we have power of 2
                    // power of two ends with 2, 4, 8, 6 respectively
                    // if we sum all x's powers of 2 and sum digits at the end
                    // and 0 == sum % 10 then 0 == x % 10 too
                    // for example x = 280 (100011000)
                    // x = 25(6) + 1(6) + 8
                    // sum = 6 + 6 + 8 = 20
                    switch (posFromRight % 4)
                    {
                        case 1:
                            sum += 2;
                            break;
                        case 2:
                            sum += 4;
                            break;
                        case 3:
                            sum += 8;
                            break;
                        case 0:
                            sum += 6;
                            break;
                    }
                }

                mask >>= 1;
                posFromRight--;
            }

            return (0 == sum % 10);
        }
    }
}
