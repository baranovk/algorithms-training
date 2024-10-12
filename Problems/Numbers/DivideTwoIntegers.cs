using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problems.Numbers
{
    public static class DivideTwoIntegers
    {
        // https://systo.ru/prog/pract/int_div.html
        // http://reshinfo.com/delenije_3.php?snA=10111001&snB=10001&sys=2&bits=32&x=29&y=7
        /*
         Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.

        Return the quotient after dividing dividend by divisor.

        The integer division should truncate toward zero, which means losing its fractional part. For example, truncate(8.345) = 8 and truncate(-2.7335) = -2.

        Note: Assume we are dealing with an environment that could only store integers within the 32-bit signed integer range: [−231, 231 − 1]. 
        For this problem, assume that your function returns 231 − 1 when the division result overflows.

        Example 1:

        Input: dividend = 10, divisor = 3
        Output: 3
        Explanation: 10/3 = truncate(3.33333..) = 3.

            7 - 1
            4 - 2
            1 - 3

            6 - 1
            3 - 2
            0 - 3

            -10 / 3
            -10 / -3
            10 / -3
            10 / 3

         */
        public static int Divide(int dividend, int divisor)
        {
            var sign = (0 < dividend && 0 < divisor) || (0 > dividend && 0 > divisor) ? 1 : -1;

            var l_dividend = Math.Abs((long)dividend);
            var l_divisor = Math.Abs((long)divisor);
            if (l_dividend < l_divisor) return 0;

            long quotient = 0;

            if (1 < l_divisor)
            {
                while (l_dividend >= l_divisor)
                {
                    l_dividend -= l_divisor;
                    quotient++;
                }
            }
            else
            {
                quotient = l_dividend;
            }

            return 0 < sign 
                ? quotient > int.MaxValue ? int.MaxValue : (int)quotient 
                : -quotient < int.MinValue ? int.MaxValue : (int)-quotient;
        }

        public static int Divide_1(int dividend, int divisor)
        {
            if (0 == divisor) return int.MaxValue;
            if (1 == divisor) return dividend;
            if (int.MinValue == dividend && -1 == divisor) return int.MaxValue;
            var sign = (0 > dividend && 0 > divisor) || (0 < dividend && 0 < divisor) ? 1 : -1;

            var l_dividend = Math.Abs((long)dividend);
            var l_divisor = Math.Abs((long)divisor);
            if (l_dividend < l_divisor) return 0;

            var divident_length = 1;
            var divisor_length = 1;

            var tmp = l_dividend;
            while (0 != (tmp = tmp >> 1)) divident_length++;

            tmp = l_divisor;
            while (0 != (tmp = tmp >> 1)) divisor_length++;

            var k = divident_length - divisor_length;

            l_divisor = l_divisor << k;
            k++;
            var result = 0;

            do
            {
                var r = l_dividend - l_divisor;
                result = result << 1;

                if (0 <= r)
                {
                    result++;
                    l_dividend = r;
                }

                l_divisor = l_divisor >> 1;
            } 
            while (0 < --k);

            return result * sign;
        }

        public static int Divide_2(int dividend, int divisor)
        {
            var capacity = 32;

            var divident_length = 1;
            var divisor_length = 1;

            var tmp = dividend;
            while (0 != (tmp = tmp >> 1)) divident_length++;

            tmp = divisor;
            while (0 != (tmp = tmp >> 1)) divisor_length++;

            var k = divident_length - divisor_length;

            var b_divident = ToBitArray(dividend, capacity);
            var b_divisor = ToBitArray(divisor << k, capacity);
            //var b_divisor_additional_code

            var result = new byte[k + 1];

            return BitConverter.ToInt32(result, 0);
        }

        public static byte[] ToBitArray(int x, int length)
        {
            var bitArray = new BitArray(BitConverter.GetBytes(x));
            var bits = new bool[length];
            bitArray.CopyTo(bits, 0);
            return bits.Select(_ => _ ? (byte)1 : (byte)0).ToArray<byte>();
        }

        public static byte[] ToAdditionalCode(byte[] num)
        {
            for (var i = 0; i < num.Length; i++)
            {
                num[i] = default(byte) == num[i] ? (byte)1 : (byte)0;
            }

            return num;
        }
    }
}
