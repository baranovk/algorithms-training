using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.TechRace;

namespace Problems.Tests.TechRace
{
    /*
     * Робин Гуд занимается перераспределением благ. Он удваивает состояние самых бедных в два раза, помогая им единожды за
     * счет капитала самых богатых – но только если капитал превышает состояние бедного в три раза.
     * Отобрать богатство Робин Гуд может несколько раз. 

       Задание: найти капитал имений после процесса перераспределения благ, не включая тех имений, которым помогал Робин Гуд.

        Входные данные🖇

        Массив из чисел, материальное состояние всех имений. Числа вводятся через запятую, без пробелов

        Пример входных данных: 27,14,58,101,3

        Выходные данные📌

        Упорядоченный от меньшего к большему список из чисел, капитала имений, которым Робин Гуд не помогал. Числа выводятся через запятую, без пробелов

        Пример выходных данных: 57,58
     */
    [TestClass]
    public class TechRace_0_Tests
    {
        [TestMethod]
        public void TestSolution()
        {
            var arr = new int[] { 27, 14, 58, 101, 3 };
            var list = TechRace_0.Solution(arr);
            Assert.AreNotEqual(0, list.Count);
        }

        [TestMethod]
        public void TestSolution_1()
        {
            var arr = new List<int> { 3, 10, 4, 8 };
            var result = TechRace_0.Solution_1(arr);
            Assert.AreEqual(11, result);

            // 5, 6, 12
            arr = new List<int> { 5, 12, 6 };
            result = TechRace_0.Solution_1(arr);
            Assert.AreEqual(7, result);
        }
    }
}
