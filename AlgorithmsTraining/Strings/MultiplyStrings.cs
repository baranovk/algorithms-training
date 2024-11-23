namespace AlgorithmsTraining.Strings;

/*
 * 43. Multiply Strings https://leetcode.com/problems/multiply-strings/description/
 * Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.

    Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.

    Example 1:

    Input: num1 = "2", num2 = "3"
    Output: "6"

    Example 2:

    Input: num1 = "123", num2 = "456"
    Output: "56088"

    Constraints:

      -  1 <= num1.length, num2.length <= 200
      -  num1 and num2 consist of digits only.
      -  Both num1 and num2 do not contain any leading zero, except the number 0 itself.

        888
        222
        ----
       1776
    + 1776
     1776
    --------
     197136

 Runtime
 2ms
 Beats 96.55%

 Memory
 40.44MB
 Beats99.53%
 */
public static class MultiplyStrings
{
    private static Dictionary<char, int> _charMap = new()
    {
        { '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 },
        { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 },
    };

    private static Dictionary<int, char> _intMap = new()
    {
        { 0, '0' }, { 1, '1' }, { 2, '2' }, { 3, '3' }, { 4, '4' },
        { 5, '5' }, { 6, '6' }, { 7, '7' }, { 8, '8' }, { 9, '9' },
    };

    /*
     * Runtime
       2ms
       Beats 96.55%
       
       Memory
       40.44MB
       Beats99.53%
     */
    public static string Solution(string num1, string num2)
    {
        if ("0" == num1 || "0" == num2) { return "0"; }

        int carry = 0, ri, resultLength = 0;
        Span<int> result = stackalloc int[num1.Length + num2.Length];

        for (int i = num1.Length - 1; i >= 0; i--) 
        {
            ri = num1.Length - 1 - i;

            for (int j = num2.Length - 1; j >= 0; j--) 
            { 
                var multiply = (num1[i] - '0') * (num2[j] - '0') + carry;
                carry = multiply / 10;
                var sum = result[ri] + multiply % 10;
                result[ri++] = sum % 10;
                result[ri] += sum / 10;
            }

            result[ri] += carry;
            resultLength = 0 == result[ri] ? ri : ri + 1;
            carry = 0;
        }

        result = result[..resultLength];
        var resultChars = new char[resultLength];

        for (int i = 0; i < result.Length; i++) { resultChars[i] = (char)('0' + result[result.Length - 1 - i]); }
        return new string(resultChars);
    }

    /*
     * Runtime
       7ms
       Beats 75.00%

     * Memory
       40.35MB
       Beats 99.76%
     */
    public static string Solution_1(string num1, string num2)
    {
        if ("0" == num1 || "0" == num2) { return "0"; }

        int carry = 0, ri, resultLength = 0;
        Span<int> result = stackalloc int[num1.Length + num2.Length];

        for (int i = num1.Length - 1; i >= 0; i--)
        {
            ri = num1.Length - 1 - i;

            for (int j = num2.Length - 1; j >= 0; j--)
            {
                var multiply = _charMap[num1[i]] * _charMap[num2[j]] + carry;
                carry = multiply / 10;
                var sum = result[ri] + multiply % 10;
                result[ri++] = sum % 10;
                result[ri] += sum / 10;
            }

            result[ri] += carry;
            resultLength = 0 == result[ri] ? ri : ri + 1;
            carry = 0;
        }

        result = result[..resultLength];
        var resultChars = new char[resultLength];

        for (int i = 0; i < result.Length; i++) { resultChars[i] = _intMap[result[result.Length - 1 - i]]; }
        return new string(resultChars);
    }
}
