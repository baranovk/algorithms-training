using System;

namespace Problems.Combinatorics
{
    public static class NextPermutation
    {
        /*
         https://habr.com/ru/post/428552/
         0 1 2 5 3 3 0
         0 1 2 5 3 3 4

        https://planetcalc.ru/8520/
        0,1,7,7,5,8
        0,1,7,7,8,5

        Слово α предшествует слову β (α   < β), если

        либо первые m  m символов этих слов совпадают, а m + 1  m+1-й символ слова α   меньше (относительно заданного в Σ порядка) m + 1 m+1-го символа слова β   
        (например, АБАК < АБРАКАДАБРА, так как первые две буквы у этих слов совпадают, а третья буква у первого слова меньше, чем у второго);
        либо слово α   является началом слова β   (например, МАТЕМАТИК < МАТЕМАТИКА

         * Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

           If such an arrangement is not possible, it must rearrange it as the lowest possible order (i.e., sorted in ascending order).

           The replacement must be in place and use only constant extra memory.

        Input: nums = [1,2,3]
        Output: [1,3,2]

        Input: nums = [3,2,1]
        Output: [1,2,3]

        Input: nums = [1,1,5]
        Output: [1,5,1]

         0  1  7  7  5  8
         0  1  7  7  8  5

        
    1. Найти такой наибольший j, для которого a_{j}<a_{j+1}.

    2. Увеличить a_{j}. Для этого надо найти наибольшее l>j, для которого a_{l}>a_{j}. Затем поменять местами a_{j} и a_{l}.

    3. Записать последовательность a_{j+1},...,a_{n} в обратном порядке.

         */
        public static void Find(int[] nums)
        {
            if (1 == nums.Length) return;

            var j = -1;
            
            for (var i = 1; i < nums.Length; i++)
            {
                if(nums[i - 1] < nums[i]) j = i - 1;
            }

            if (j < 0)
            {
                Array.Sort(nums);
                return;
            }
            
            var l = j + 1;

            for (var i = l + 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[j]) l = i;
            }

            if (l < nums.Length)
            {
                var t = nums[j];
                nums[j] = nums[l];
                nums[l] = t;
            }

            Array.Reverse(nums, j + 1, nums.Length - (j + 1));
        }
    }
}
