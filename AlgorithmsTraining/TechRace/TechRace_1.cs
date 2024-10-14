using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsTraining.TechRace
{
    public class TechRace_1
    {
        public static List<Tuple<int, int>> Solution(int n, string request)
        {
            var result = new List<Tuple<int, int>>();
            var ratings = request.Split(',').Select(_ => Convert.ToInt32(_)).ToArray();
            Array.Sort(ratings);

            var padavanPointer = 0;

            while (padavanPointer < ratings.Length - 1)
            {
                var mentorPointer = ratings.Length;

                while (--mentorPointer > padavanPointer)
                {
                    if (n == ratings[mentorPointer] / ratings[padavanPointer])
                    {
                        result.Add(new Tuple<int, int>(ratings[padavanPointer], ratings[mentorPointer]));
                    }
                }

                padavanPointer++;
            }

            return result;
        }
    }
}
