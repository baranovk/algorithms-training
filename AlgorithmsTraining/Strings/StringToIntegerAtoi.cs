using System;

namespace AlgorithmsTraining.Strings
{
    public static class StringToIntegerAtoi
    {
        public static int Convert(string str)
        {
            // int.Max =  2 147 483 647
            // int.Min = -2 147 483 647
            if (string.IsNullOrEmpty(str)) return 0;

            var list = new int[10];
            int i = 0, j = -1;
            int modificator = 1;

            while (i < str.Length && (' ' == str[i] || '-' == str[i] || '+' == str[i]))
            {
                if ('-' == str[i] || '+' == str[i])
                {
                    modificator = '-' == str[i] ? -1 : 1;
                    i++;
                    break;
                }

                i++;
            }

            while (i < str.Length && '0' == str[i])
            {
                i++;
            }

            for ( ; i < str.Length; i++)
            {
                if('0' > str[i] || '9' < str[i])
                    break;

                if (j == list.Length - 1)
                    return 0 > modificator ? int.MinValue : int.MaxValue;

                list[++j] = str[i] - '0';
            }

            double result = 0;

            for (i = 0; i <= j; result += list[j - i] * Math.Pow(10, i), i++) ;

            result = modificator * result;
            return 0 <= result ? (int) Math.Min(result, int.MaxValue) : (int) Math.Max(result, int.MinValue);
        }
    }
}
