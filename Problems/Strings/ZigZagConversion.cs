using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Strings
{
    public static class ZigZagConversion
    {
        /*
        P A Y P A L I S H I R I N G
        0 1 2 3 4 5 6 7 8 9 0 1 2 3

        numRows - 2 + numRows
        numRows = 3 = 4
        =======================================
        P   A   H   N
        A P L S I I G
        Y   I   R

        0  4  8  12
        1  3  5  7  9  11  13
        2  6  10
        =======================================


        =======================================
        P     I    N     O
        A   L S  I G   E N
        Y A   H R  S M   E
        P     I    O

        0  6  12
        1  5  7  11  13
        2  4  8  10  14
        3  9
        =======================================
        P  Y  A
        A  P  L


        P     H     M 
        A   S I   O E
        Y  I  R  S  O
        P L   I G   N
        A     N     E
         */
        public static string Convert(string s, int numRows)
        {
            /*
             создать массив char[s.Length]
             и его заполнять


             P A Y P A L I S H I R I N G
             0 1 2 3 4 5 6 7 8 9 0 1 2 3

             P   A   H   N
             A P L S I I G
             Y   I   R

            P   A   H   N A P L S I I G Y   I   R
            =========================================
            numRows = 3
            shift = 4
            s.Length = 14
            
            P A H N
            J = 1, J <= 1
             */
            var sb = new StringBuilder();
            var shift = 2 * numRows - 2;

            for (var i = 0; i < s.Length; i += shift)
            {
                sb.Append(s[i]);
            }

            for (var j = 1; j <= numRows - 2; j++)
            {
                for (var i = 0; i < s.Length; i += shift)
                {
                    sb.Append(s[i]);

                    if (i + j < s.Length)
                        sb.Append(s[i + j]);

                    if (0 <= i - j)
                        sb.Append(s[i - j]);
                }
            }

            for (var i = numRows - 1; i < s.Length; i += shift)
            {
                sb.Append(s[i]);
            }

            return sb.ToString();
        }

        public static string Convert_1(string s, int numRows)
        {
            /*
            numRows = 3
            shift = 4
            s.Length = 14

             P   A   H   N
             A P L S I I G
             Y   I   R
             
            j = 0
            P 
            j = 1
            A 
            j = 2
            Y  I
             */
            var result = new char[s.Length];
            var index = -1;
            var shift = Math.Max(1, 2 * numRows - 2);

            for (var j = 0; j < numRows; j++)
            {
                for (var i = j; i < s.Length; i += shift)
                {
                    result[++index] = s[i];
                    var next = i + shift - 2 * j;

                    if (i + shift > next && i < next && next < s.Length)
                        result[++index] = s[next];
                }
            }
            

            return new string(result);
        }
    }
}
