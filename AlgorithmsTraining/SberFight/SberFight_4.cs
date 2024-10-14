using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsTraining.SberFight
{
    /*
     * На вход подается числовой массив. За одну операцию вы можете разделить любое число в массиве на два (целочисленное деление).
     * Определите, может ли сумма всех элементов в массиве быть не больше w. Общее количество операций не должно превышать значение
     * самого большого числа в массиве. 

        Возможное общее количество операций меняется динамически, то есть если Вы будете делить самое крупное число, то общее количество 
        возможных операций уменьшится, и так на каждом шаге.

        Ввод:

        arr - массив чисел (integer[]), 1<length(arr)<10
        w - число, максимальный предел для суммы массива (integer), 0<w<100
        Вывод:

        Boolean - возможно ли удовлетворить условие sum(arr) <= w
        Пример:

        arr = [3, 2, 4, 5]
        W = 9
        GetResult(arr, W) = true

        Сначала количество возможных операций равно 5 (самое большое число в исходном массиве)
        5 // 2 = 2 [3, 2, 4, 2], теперь количество проведенных операций равно 1, а число возможных операций - 4
        4 // 2 = 2 [3, 2, 2, 2], теперь количество проведенных операций равно 2, а число возможных операций - 3
        Уже сейчас выполняется условие: 3 + 2 + 2 + 2 <= 9
     */
    public class SberFight_4
    {
        public static bool Solution(List<int> arr, int w)
        {
            if (1 == arr.Count) return arr[0] <= w;

            var sum = arr.Sum();
            if (sum <= w) return true;

            arr.Sort();

            var operationsCounter = 0;
            var maxNumberIndex = arr.Count - 1;

            while (sum > w && operationsCounter <= arr[maxNumberIndex])
            {
                var newNumber = arr[maxNumberIndex] >> 1;
                sum -= (arr[maxNumberIndex] - newNumber);
                arr[maxNumberIndex] = newNumber;
                operationsCounter++;

                var i = maxNumberIndex;

                while (1 < i && arr[i - 1] > arr[i])
                {
                    var t = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = t;
                    i--;
                }
            }

            return sum <= w;
        }
    }
}
