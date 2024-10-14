using System;
using System.Collections.Generic;

namespace AlgorithmsTraining.SberFight
{
    public class SberFight_2
    {
        /*
         * Вы играете в игру, где ваш персонаж прыгает по заборчикам. Значения в массиве означают, сколько заборчиков персонаж обязан перешагнуть, двигаясь вперед.
         * Вы можете менять элементы в массиве местами. 

Чтобы выиграть, персонажу нужно дойти до финиша, в нашем случае - это добраться до последнего индекса массива. 
        Выведите true, если победить в игре возможно, в противном случае - false.

Ввод: 

fences - массив значений длин прыжков. Герой начинает с нулевого индекса
Вывод: 

Boolean - возможно ли победить
Example:

fences = [0, 2, 4, 1, 6, 2]
GetResult(fences) = True

Один из возможных вариантов: [1, 4, 2, 0, 6, 2]. Герой с 0-го индекса прыгнул на 1-ый, и сразу же смог прыгнуть на последний индекс массива - он победил
         */
        public static bool Solution(List<int> fences)
        {
            var fencesArr = fences.ToArray();
            Array.Sort(fencesArr);

            do
            {
                var index = 0;

                while (0 <= index && index < fencesArr.Length)
                {
                    if(0 == fencesArr[index]) break;
                    index += fencesArr[index];
                    if (index == fencesArr.Length - 1) return true;
                }
            } while (GetNextPermutation(fencesArr));

            return false;
        }

        private static bool GetNextPermutation(int[] nums)
        {
            if (1 == nums.Length) return true;

            var j = -1;

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] < nums[i]) j = i - 1;
            }

            if (j < 0)
            {
                Array.Sort(nums);
                return false;
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
            return true;
        }
    }
}
